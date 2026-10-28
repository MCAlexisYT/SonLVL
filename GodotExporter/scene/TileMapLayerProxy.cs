using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SonicRetro.SonLVL.API.XMLDef;

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

		public SceneInternalResource TileSet;
		public Dictionary<Variant.Vector2i, TileMapCell> Tiles;

		public override SceneNode ToNode(string name)
		{
			List<byte> byteArray = new List<byte>();

			// corresponds to this line: https://github.com/godotengine/godot/blob/cafc17a192acf67903910a68aeb3c076c0907a4b/modules/tilemap/tile_map_layer.h#L44
			Marshalls.encode_uint16((ushort)0, byteArray);

			foreach (KeyValuePair<Variant.Vector2i, TileMapCell> cell in Tiles) {
				// tile position in tilemap
				Marshalls.encode_uint16((ushort)cell.Key.X, byteArray);
				Marshalls.encode_uint16((ushort)cell.Key.Y, byteArray);
				// tile identifiers
				Marshalls.encode_uint16((ushort)cell.Value.source_id, byteArray);
				Marshalls.encode_uint16((ushort)cell.Value.coord_x, byteArray);
				Marshalls.encode_uint16((ushort)cell.Value.coord_y, byteArray);
				Marshalls.encode_uint16((ushort)cell.Value.alternative_tile, byteArray);
			}

			return new SceneNode
			{
				Type = "TileMapLayer",
				Name = name,
				KVs =
				{
					{"tile_set", Variant.FromInternalResource(TileSet)},
					{"tile_map_data", Variant.FromPrimitiveArray(byteArray.ToArray())}
				}
			};
		}
	}

}
