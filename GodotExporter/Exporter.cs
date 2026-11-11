using System.Collections.Generic;
using SonicRetro.SonLVL.API;
using System;
using SonicRetro.SonLVL.GodotExporter.scene;
using System.IO;
using System.Windows.Forms;
using SonicRetro.SonLVL.API.XMLDef;

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

			SceneNode root_node = new SceneNode();
			root_node.Type = "Node2D";
			root_node.Name = "LevelGeo";

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

			for (int iX = 0; iX < LevelData.BGWidth; iX++)
			{
				for (int iY = 0; iY < LevelData.BGHeight; iY++)
				{
					background.Tiles[new Point(iX, iY)] = new TileMapLayerProxy.TileMapCell
					{
						source_id = 2,
						coord_x = 0,
						coord_y = LevelData.Layout.BGLayout[iX, iY],
						alternative_tile = 0,
					};
				}
			}
			for (int iX = 0; iX < LevelData.FGWidth; iX++)
			{
				for (int iY = 0; iY < LevelData.FGHeight; iY++)
				{
					foreground.Tiles[new Point(iX, iY)] = new TileMapLayerProxy.TileMapCell
					{
						source_id = 0,
						coord_x = 0,
						coord_y = LevelData.Layout.FGLayout[iX, iY],
						alternative_tile = 0,
					};
					priority_foreground.Tiles[new Point(iX, iY)] = new TileMapLayerProxy.TileMapCell
					{
						source_id = 0,
						coord_x = 0,
						coord_y = LevelData.Layout.FGLayout[iX, iY],
						alternative_tile = 0,
					};
				}
			}

			#endregion

			scene.Nodes.Add(background.ToNode("background"));
			scene.Nodes.Add(foreground.ToNode("foreground"));
			scene.Nodes.Add(priority_foreground.ToNode("priority_foreground"));

			string str = scene.ToString();

			File.WriteAllText(Path.Combine(GodotProjectRoot, LevelPaths[level_name]), str);
        }
    }
}