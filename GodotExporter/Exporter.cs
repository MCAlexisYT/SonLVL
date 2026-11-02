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

			Scene scene = new Scene();

			Chunk[] chunks = LevelData.Chunks.ToArray();

			#region tileset creation stuff

			ImageProxy img_not_priority = ImageProxy.FromAllChunks(false);
			ImageProxy img_priority = ImageProxy.FromAllChunks(true);
			
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
					img_priority
				}),
				TileSize = new Variant.Vector2i(LevelData.Level.ChunkWidth, LevelData.Level.ChunkHeight)
			};

			// tile generation
			for (int i = 0; i < chunks.Length; i++)
			{
				
			}

			#endregion

			SceneInternalResource[] tileset_resources = tileset.ToResource("tileset");
			scene.Resources.AddRange(tileset_resources);

			TileMapLayerProxy background = new TileMapLayerProxy
			{
				TileSet = tileset_resources[0],
			};

			TileMapLayerProxy foreground = new TileMapLayerProxy
			{
				TileSet = tileset_resources[0],
			};

			TileMapLayerProxy priority_foreground = new TileMapLayerProxy
			{
				TileSet = tileset_resources[0],
			};

			#region generate tiles



			#endregion

			scene.Nodes.Add(foreground.ToNode("foreground"));
			scene.Nodes.Add(priority_foreground.ToNode("priority_foreground"));

			string str = scene.ToString();

			File.WriteAllText(Path.Combine(GodotProjectRoot, LevelPaths[level_name]), str);
        }
    }
}