using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicRetro.SonLVL.GodotExporter.scene
{
	public class TileSetProxy
	{
		public struct TileData
		{
			// int corresponds to a physics layer.
			// each List<Variant.Vector2> represents a single collision polygon.
			public Dictionary<int, List<List<Variant.Vector2>>> polygons;
			public int z_index;

		}
		public Variant.Vector2i TileSize = new Variant.Vector2i(128, 128);
		// each entry (of both Textures and Tiles) corresponds to a tile source (like an image/texture)
		public List<Dictionary<Variant.Vector2i, TileData>> Tiles;
		public List<ImageProxy> Textures;

		public Dictionary<int, int> CollisionLayers;

		public SceneInternalResource[] ToResource(string id)
		{
			SceneInternalResource res = new SceneInternalResource
			{
				Type = "TileSet",
				ID = id
			};


			List<SceneInternalResource> list = new List<SceneInternalResource>();
			int i = 0;
			foreach (Dictionary<Variant.Vector2i, TileData> tiles in Tiles)
			{
				SceneInternalResource atlas = new SceneInternalResource
				{
					Type = "TileSetAtlasSource",
					ID = "TileSetAtlasSource_" + i.ToString(),
					KVs = new Dictionary<string, Variant>()
				};

				foreach (KeyValuePair<Variant.Vector2i, TileData> tile in tiles)
				{
					string key = tile.Key.X.ToString() + ":" + tile.Key.Y.ToString() + "/0";
					atlas.KVs[key] = Variant.FromPrimitive("0");
					foreach (KeyValuePair<int, List<List<Variant.Vector2>>> physics_layer in tile.Value.polygons)
					{
						string key2 = key + "/physics_layer_" + physics_layer.Key.ToString();
						for (int i2 = 0; i2 < physics_layer.Value.Count; i2++)
						{
							string key3 = key2 + "/polygon_" + i2 + "/points";
							atlas.KVs[key3] = Variant.FromVec2Array(physics_layer.Value[i2]);
						}
					}
				}

				list.Add(atlas);
				i++;
			}

			foreach (KeyValue<int, int> layer in CollisionLayers)
			{
				atlas.KVs["physics_layer_" + layer.Key + "/collision_layer"] = Variant.FromPrimitive(layer.Value);
				atlas.KVs["physics_layer_" + layer.Key + "/collision_mask"] = Variant.FromPrimitive(layer.Value);
			}
			return list.ToArray();
		}
	}
}
