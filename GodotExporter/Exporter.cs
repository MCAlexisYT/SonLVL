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

			#region tileset graphics generation stuff

			ImageProxy img_not_priority = ImageProxy.FromAllChunks(false);
			ImageProxy img_priority = ImageProxy.FromAllChunks(true);

			#endregion

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
			TilesetProxy tileset = new TileSetProxy
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
					{ 9, coll_layer_2h },
				},
				Textures = new List<ImageProxy>(new ImageProxy[]
				{
					img_not_priority,
					img_priority
				}),
				TileSize = new Variant.Vector2i(LevelData.Level.ChunkWidth, LevelData.Level.ChunkHeight)
			};

			// tile generation
			for (int i = 0; i < LevelData.Level.Chunks.Length; i++)
			{
				
			}

			#endregion
			

			TileMapLayerProxy background = new TileMapLayerProxy
			{
				TileSet = tileset,
			};

			TileMapLayerProxy foreground = new TileMapLayerProxy
			{
				TileSet = tileset,
			};

			TileMapLayerProxy priority_foreground = new TileMapLayerProxy
			{
				TileSet = tileset,
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