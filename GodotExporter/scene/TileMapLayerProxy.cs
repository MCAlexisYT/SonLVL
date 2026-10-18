using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicRetro.SonLVL.GodotExporter.scene
{
	// This class's code is heavily based on that of the TileMapLayer node in Godot's source code.
	public class TileMapLayerProxy
	{
		public struct TileMapCell
		{
			public short source_id;
			public short coord_x;
			public short coord_y;
			public short alternative_tile;
		}
		public struct CellData
		{
			Variant.Vector2i coords;
			TileMapCell cell;
		}

		public SceneInternalResource TileSet;
		public Dictionary<Variant.Vector2i, CellData> Tiles;

	}

}
