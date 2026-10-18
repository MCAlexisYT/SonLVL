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
			public List<List<List<Variant.Vector2>>> polygons;
			public int z_index;

		}
	}
}
