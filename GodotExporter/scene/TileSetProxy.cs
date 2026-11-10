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

			int coll_layer_0 = 0b0001;
			int coll_layer_1 = 0b1111;
			int coll_layer_2 = 0b1110;
			int coll_layer_0l = coll_layer_0 << 4;
			int coll_layer_1l = coll_layer_1 << 4;
			int coll_layer_2l = coll_layer_2 << 4;
			int coll_layer_0h = coll_layer_0 << 8;
			int coll_layer_1h = coll_layer_1 << 8;
			int coll_layer_2h = coll_layer_2 << 8;
			TileSetProxy tileset = new TileSetProxy
			{
				CollisionLayers = {
					{ 0, coll_layer_0 },
					{ 1, coll_layer_1 },
					{ 2, coll_layer_2 },
					{ 3, coll_layer_0l },
					{ 4, coll_layer_1l },
					{ 5, coll_layer_2l },
					{ 6, coll_layer_0h },
					{ 7, coll_layer_1h },
					{ 8, coll_layer_2h },
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
				col_blocks[i] = new List<List<PointF>>();
				
				for (int iY = 0; iY < 16; iY++)
				{
					col_blocks[i].Add(new List<PointF>());
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
						col_blocks[i][iY].AddRange(new PointF[]{
							new PointF(start, iY),
							new PointF(end, iY),
							new PointF(end, iY + 1),
							new PointF(start, iY + 1)
						});
					}
				}
			}

			#endregion

			// tile generation
			for (int i2 = 0; i2 < 3; i2++)
			{
				tileset.Tiles.Add(new Dictionary<Point, TileData> { });
			}
			for (int i = 0; i < chunks.Length; i++)
			{

				tileset.Tiles[1][new Point(0, i)] = new TileData();
				tileset.Tiles[2][new Point(0, i)] = new TileData();
			}

			#endregion

			return tileset;
		}

		private static SceneInternalResource ImageTextureScript = new SceneInternalResource
		{
			ID = "ImageTextureScript",
			Type = "GDScript",
			KVs =
			{
				{"script/source", Variant.FromPrimitive(@"
					extends ImageTexture

					@export var image: Image

					func _init() -> void:
						set_image(image)
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
