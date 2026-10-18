using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicRetro.SonLVL.GodotExporter
{
	internal class Marshalls
	{
		public static void encode_uint16(ushort p_uint, List<byte> p_bytes)
		{
			for (int i = 0; i < 2; i++)
			{
				p_bytes.Add((byte)(p_uint & 0xFF));
				p_uint >>= 8;
			}
		}

	}
}
