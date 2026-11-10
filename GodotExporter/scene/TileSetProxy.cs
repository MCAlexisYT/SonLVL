using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using SonicChunk = SonicRetro.SonLVL.API.Chunk;

namespace SonicRetro.SonLVL.GodotExporter.scene
{
	public class TileSetProxy
	{
		public struct TileData
		{
			// int corresponds to a physics layer.
			// each List<Variant.Vector2> represents a single collision polygon.
			public Dictionary<int, List<List<PointF>>> polygons;
			public int z_index;

		}
		public Size TileSize = new Size(128, 128);
		// each entry (of both Textures and Tiles) corresponds to a tile source (like an image/texture)
		public List<Dictionary<Point, TileData>> Tiles;
		public List<ImageProxy> Textures;

		public Dictionary<int, int> CollisionLayers;

		public static TileSetProxy FromAllChunks()
		{
			SonicChunk[] chunks = LevelData.Chunks.ToArray();

			#region tileset creation stuff

			ImageProxy img_not_priority = ImageProxy.FromAllChunks(false);
			ImageProxy img_priority = ImageProxy.FromAllChunks(true);
			ImageProxy img_both = ImageProxy.FromBackgroundChunks();

			int coll_layer_topsolid = 0b0001;
			int coll_layer_allsolid = 0b1111;
			int coll_layer_lrbsolid = 0b1110;
			int coll_layer_topsolid_l  = coll_layer_topsolid << 4;
			int coll_layer_allsolid_l  = coll_layer_allsolid << 4;
			int coll_layer_lrbsolid_l  = coll_layer_lrbsolid << 4;
			int coll_layer_topsolid_h  = coll_layer_topsolid << 8;
			int coll_layer_allsolid_h  = coll_layer_allsolid << 8;
			int coll_layer_lrbsolid_h  = coll_layer_lrbsolid << 8;
			TileSetProxy tileset = new TileSetProxy
			{
				CollisionLayers = {
					{ 0, coll_layer_topsolid},
					{ 1, coll_layer_allsolid },
					{ 2, coll_layer_lrbsolid },
					{ 3, coll_layer_topsolid_l  },
					{ 4, coll_layer_allsolid_l  },
					{ 5, coll_layer_lrbsolid_l  },
					{ 6, coll_layer_topsolid_h  },
					{ 7, coll_layer_allsolid_h  },
					{ 8, coll_layer_lrbsolid_h  },
				},
				Textures = new List<ImageProxy>(new ImageProxy[]
				{
					img_not_priority,
					img_priority,
					img_both
				}),
				TileSize = new Size(LevelData.Level.ChunkWidth, LevelData.Level.ChunkHeight)
			};

			#region collision block generation

			List<List<PointF>>[] col_blocks = new List<List<PointF>>[256];
			BitmapBits[] col_bmpbits = new BitmapBits[LevelData.ColBmpBits.Length];
			int j = 0;
			foreach (BitmapBits img in LevelData.ColBmpBits)
			{
				col_bmpbits[j] = new BitmapBits(img.Width + 2, img.Height + 2);
				col_bmpbits[j].FloodFill(0, new Point(0, 0));
				col_bmpbits[j].DrawBitmap(img, new Point(1, 1));
				j++;
			}

			for (int i = 0; i < 256; i++)
			{
				// builds collision tiles in horizontal strips (the geometry will get optimized by godot at runtime anyway)
				col_blocks[i] = new List<List<PointF>>();
				
				for (int iY = 0; iY < 16; iY++)
				{
					List<PointF> strip = new List<PointF>();
					bool has_found = false;
					int start = 0;
					int end = 15;
					for (int iX = 0; iX < 16; iX++)
					{
						if (!has_found)
						{
							if (col_bmpbits[i].Bits[col_bmpbits[i].GetPixelIndex(iX, iY)] > 0)
							{
								has_found = true;
								start = iX;
							}
						}
						else
						{
							if (!(col_bmpbits[i].Bits[col_bmpbits[i].GetPixelIndex(iX, iY)] > 0)) {
								end = iX;
							}
						}
					}
					if (has_found)
					{
						strip.AddRange(new PointF[]{
							new PointF(start, iY),
							new PointF(end, iY),
							new PointF(end, iY + 1),
							new PointF(start, iY + 1)
						});
						col_blocks[i].Add(strip);
					}
				}
			}

			#endregion

			bool chunk_is_s2 = false;
			switch (LevelData.Game.ChunkFormat)
			{
				case EngineVersion.S2:
				case EngineVersion.S2NA:
				case EngineVersion.S3K:
				case EngineVersion.SKC:
					chunk_is_s2 = true;
					break;
			}
			// tile generation
			for (int i2 = 0; i2 < 3; i2++)
			{
				tileset.Tiles.Add(new Dictionary<Point, TileData> { });
			}
			for (int i = 0; i < chunks.Length; i++)
			{
				TileData tiles = new TileData
				{
					z_index = 0,
					polygons =
					{
						{3, new List<List<PointF>>()},
						{4, new List<List<PointF>>()},
						{5, new List<List<PointF>>()},
						{6, new List<List<PointF>>()},
						{7, new List<List<PointF>>()},
						{8, new List<List<PointF>>()}
					}
				};
				tileset.Tiles[1][new Point(0, i)] = new TileData
				{
					z_index = 9999999
				};
				tileset.Tiles[2][new Point(0, i)] = new TileData
				{
					z_index = 0
				};

				for (int iX = 0; iX < tileset.TileSize.Width / 16; iX++)
				{
					for (int iY = 0; iY < tileset.TileSize.Height / 16; iY++)
					{
						ChunkBlock block = chunks[i].Blocks[iX, iY];
						Solidity sol1 = block.Solid1;
						byte sol1_idx = LevelData.GetColInd1(block.Block);
						if (sol1 != Solidity.NotSolid)
						{
							tiles.polygons[solidity(sol1, false)].AddRange(
								col_offset(
									iX * 16 - tileset.TileSize.Width / 2,
									iY * 16 - tileset.TileSize.Height / 2,
									col_blocks[sol1_idx]
								)
							);
						}
						if (chunk_is_s2)
						{
							S2ChunkBlock block2 = (S2ChunkBlock)block;
							Solidity sol2 = block2.Solid2;
							byte sol2_idx = LevelData.GetColInd2(block.Block);

							if (sol2 != Solidity.NotSolid)
							{
								tiles.polygons[solidity(sol2, true)].AddRange(
									col_offset(
										iX * 16 - tileset.TileSize.Width / 2,
										iY * 16 - tileset.TileSize.Height / 2,
										col_blocks[sol2_idx]
									)
								);
							}
						}
					}
				}

				tileset.Tiles[0][new Point(0, i)] = tiles;
			}

			#endregion

			return tileset;
		}

		private static int solidity(Solidity sol, bool is_priority)
		{
			switch (sol)
			{
				case Solidity.TopSolid:
					return is_priority ? 6 : 3;
					break;
				case Solidity.AllSolid:
					return is_priority ? 7 : 4;
					break;
				case Solidity.LRBSolid:
					return is_priority ? 8 : 5;
					break;
			}
			return -1;
		}

		private static List<List<PointF>> col_offset(int x, int y, List<List<PointF>> block)
		{
			List<List<PointF>> output = new List<List<PointF>>();

			PointF point = new PointF(x, y);
			foreach (List<PointF> strip in block)
			{
				output.Add(new List<PointF>
				{
					strip[0] + point,
					strip[1] + point,
					strip[2] + point,
					strip[3] + point
				});
			}

			return output;
		}

		private static SceneInternalResource ImageTextureScript = new SceneInternalResource
		{
			ID = "ImageTextureScript",
			Type = "GDScript",
			KVs =
			{
				{"script/source", Variant.FromPrimitive(@"
					extends ImageTexture

					@export var image: Image:
						set(value):
							set_image(value)
							image = value
				") }
			}
		};

		public static SceneInternalResource ImageTextureResource(ImageProxy img)
		{
			return new SceneInternalResource
			{
				Type = "ImageTexture",
				ID = img.ID + "_texture",
				KVs =
				{
					{"script", Variant.FromInternalResource(ImageTextureScript) },
					{"image", Variant.FromInternalResource(img.ToResource()) }
				}
			};
		}

		public SceneInternalResource[] ToResource(string id)
		{
			SceneInternalResource res = new SceneInternalResource
			{
				Type = "TileSet",
				ID = id,
				KVs = new Dictionary<string, Variant>()
			};


			List<SceneInternalResource> list = new List<SceneInternalResource>();
			list.Add(ImageTextureScript);
			int i = 0;
			foreach (Dictionary<Point, TileData> tiles in Tiles)
			{

				SceneInternalResource atlas = new SceneInternalResource
				{
					Type = "TileSetAtlasSource",
					ID = id + "AtlasSource_" + i.ToString(),
					KVs = new Dictionary<string, Variant>()
				};

				foreach (KeyValuePair<Point, TileData> tile in tiles)
				{
					string key = tile.Key.X.ToString() + ":" + tile.Key.Y.ToString() + "/0";
					atlas.KVs[key] = Variant.FromPrimitive("0");
					foreach (KeyValuePair<int, List<List<PointF>>> physics_layer in tile.Value.polygons)
					{
						string key2 = key + "/physics_layer_" + physics_layer.Key.ToString();
						for (int i2 = 0; i2 < physics_layer.Value.Count; i2++)
						{
							string key3 = key2 + "/polygon_" + i2 + "/points";
							atlas.KVs[key3] = Variant.FromVec2Array(physics_layer.Value[i2].ToArray());
						}
					}
				}

				foreach (KeyValuePair<int, int> layer in CollisionLayers)
				{
					atlas.KVs["physics_layer_" + layer.Key + "/collision_layer"] = Variant.FromPrimitive(layer.Value);
					atlas.KVs["physics_layer_" + layer.Key + "/collision_mask"] = Variant.FromPrimitive(layer.Value);
				}

				SceneInternalResource texture = ImageTextureResource(Textures[i]);
				atlas.KVs["texture"] = Variant.FromInternalResource(texture);

				list.Add(atlas);
				list.Add(texture);
				res.KVs["sources/" + i.ToString()] = Variant.FromInternalResource(atlas);
				i++;
			}
			foreach (ImageProxy item in Textures)
			{
				list.Add(item.ToResource());
			}
			return list.ToArray();
		}

		/*
		public static TileSetProxy FromGodotTres(string data)
		{
			TileSetProxy tileset = new TileSetProxy();

			SceneResourceFile = SceneResourceFile

			return tileset;
		}
		*/
	}
}
