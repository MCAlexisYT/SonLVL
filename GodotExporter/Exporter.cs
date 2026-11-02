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
			
			Variant coll_layer_0 = Variant.FromPrimitive(1 << 0);
			Variant coll_layer_1 = Variant.FromPrimitive(1 << 0 & 1 << 1 & 1 << 2 & 1 << 3);
			Variant coll_layer_2 = Variant.FromPrimitive(1 << 1 & 1 << 2 & 1 << 3);
			Variant coll_layer_0l = Variant.FromPrimitive(coll_layer_0.IntValue << 4);
			Variant coll_layer_1l = Variant.FromPrimitive(coll_layer_1.IntValue << 4);
			Variant coll_layer_2l = Variant.FromPrimitive(coll_layer_2.IntValue << 4);
			Variant coll_layer_0h = Variant.FromPrimitive(coll_layer_0.IntValue << 8);
			Variant coll_layer_1h = Variant.FromPrimitive(coll_layer_1.IntValue << 8);
			Variant coll_layer_2h = Variant.FromPrimitive(coll_layer_2.IntValue << 8);
			TileSetProxy tileset = new TileSetProxy
			{
				CollisionLayers = {
					{ 0, coll_layer_0.IntValue },
					{ 1, coll_layer_1.IntValue },
					{ 2, coll_layer_2.IntValue },
					{ 3, coll_layer_0l.IntValue },
					{ 4, coll_layer_1l.IntValue },
					{ 5, coll_layer_2l.IntValue },
					{ 6, coll_layer_0h.IntValue },
					{ 7, coll_layer_1h.IntValue },
					{ 9, coll_layer_2h.IntValue },
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