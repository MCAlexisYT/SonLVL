using System.Collections.Generic;
using SonicRetro.SonLVL.API;
using System;
using SonicRetro.SonLVL.GodotExporter.scene;
using System.IO;
using System.Windows.Forms;

namespace SonicRetro.SonLVL.GodotExporter
{
	public static class Exporter
	{
		public static string GodotProjectRoot;

		// format: key: object definition, value: scene path (relative to GodotProjectRoot)
		public static Dictionary<ObjectDefinition, string> ObjPaths;

		// format: key: level name, value: level path (relative to GodotProjectRoot)
		public static Dictionary<string, string> LevelPaths;

		public static void Export()
		{
			Scene scene = new Scene();

			Chunk[] chunks = LevelData.Chunks.ToArray();

			#region tileset creation stuff
			Variant coll_layer_0 = Variant.FromPrimitive(1 << 0);
			Variant coll_layer_1 = Variant.FromPrimitive(1 << 0 & 1 << 1 & 1 << 2 & 1 << 3);
			Variant coll_layer_2 = Variant.FromPrimitive(1 << 1 & 1 << 2 & 1 << 3);
			Variant coll_layer_0l = Variant.FromPrimitive(coll_layer_0.IntValue << 4);
			Variant coll_layer_1l = Variant.FromPrimitive(coll_layer_1.IntValue << 4);
			Variant coll_layer_2l = Variant.FromPrimitive(coll_layer_2.IntValue << 4);
			Variant coll_layer_0h = Variant.FromPrimitive(coll_layer_0.IntValue << 8);
			Variant coll_layer_1h = Variant.FromPrimitive(coll_layer_1.IntValue << 8);
			Variant coll_layer_2h = Variant.FromPrimitive(coll_layer_2.IntValue << 8);
			SceneInternalResource tileset = new SceneInternalResource
			{
				ID = "tileset",
				Type = "TileSet",
				KVs =
				{
					{ "physics_layer_0/collision_layer", coll_layer_0 },
					{ "physics_layer_0/collision_mask", coll_layer_0 },
					{ "physics_layer_1/collision_layer", coll_layer_1 },
					{ "physics_layer_1/collision_mask", coll_layer_1 },
					{ "physics_layer_2/collision_layer", coll_layer_2},
					{ "physics_layer_2/collision_mask", coll_layer_2 },
					{ "physics_layer_3/collision_layer", coll_layer_0l },
					{ "physics_layer_3/collision_mask", coll_layer_0l },
					{ "physics_layer_4/collision_layer", coll_layer_1l },
					{ "physics_layer_4/collision_mask", coll_layer_1l },
					{ "physics_layer_5/collision_layer", coll_layer_2l },
					{ "physics_layer_5/collision_mask", coll_layer_2l },
					{ "physics_layer_6/collision_layer", coll_layer_0h },
					{ "physics_layer_6/collision_mask", coll_layer_0h },
					{ "physics_layer_7/collision_layer", coll_layer_1h },
					{ "physics_layer_7/collision_mask", coll_layer_1h },
					{ "physics_layer_8/collision_layer", coll_layer_2h },
					{ "physics_layer_8/collision_mask", coll_layer_2h },
				}
			};
			#endregion

			#region tileset graphics generation stuff



			#endregion

			SceneNode background = new SceneNode
			{
				Type = "TileMapLayer",
				Name = "Background",
				KVs = {
					{"tile_set", Variant.FromInternalResource(tileset) }
				}
			};

			SceneNode foreground = new SceneNode
			{
				Type = "TileMapLayer",
				Name = "Foreground",
				KVs = {
					{"tile_set", Variant.FromInternalResource(tileset)}
				}
			};

			SceneNode priority_foreground = new SceneNode
			{
				Type = "TileMapLayer",
				Name = "PriorityForeground",
				KVs =
				{
					{"tile_set", Variant.FromInternalResource(tileset)}
				}
			};

			#region generate tiles



			#endregion

			scene.Nodes.Add(foreground);

			string str = scene.ToString();

			string level_name = "";

			foreach (var item in LevelData.Game.Levels)
			{
				if (item.Value == LevelData.Level)
				{
					level_name = item.Key;
					break;
				}
			}

			if (level_name == "")
			{
				MessageBox.Show(
					"Could not find the level currently being exported in the internal \"level-name-to-scene-path\" database. Like, HOW?!",
					"Export error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			File.WriteAllText(Path.Combine(GodotProjectRoot, LevelPaths[level_name]), str);
        }
    }
}