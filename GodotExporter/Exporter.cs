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

			TileSetProxy tileset = TileSetProxy.FromAllChunks();

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