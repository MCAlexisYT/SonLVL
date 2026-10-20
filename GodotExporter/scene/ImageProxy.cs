using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SonicRetro.SonLVL.GodotExporter.Variant;

namespace SonicRetro.SonLVL.GodotExporter.scene
{
	public class ImageProxy
	{
		public Color[,] Pixels;
		public Size Size;

		public ImageProxy(int width, int height)
		{

		}

		public static ImageProxy FromChunk(Chunk chunk, bool is_priority)
		{
			bool is_s2 = false;
			switch (LevelData.Level.ChunkFormat)
			{
				case EngineVersion.S2:
				case EngineVersion.S2NA:
				case EngineVersion.S3K:
				case EngineVersion.SKC:
					is_s2 = true;
					break;
			}
			ImageProxy img = new ImageProxy((is_s2) ? 128 : 256, (is_s2) ? 128 : 256);




			return img;
		}

		public string ID;

		public void SetPixel(Point point, System.Drawing.Color color)
		{
			Pixels[point.X, point.Y] = color;
		}

		public SceneInternalResource ToResource()
		{
			List<byte> data = new List<byte>();

			for (int iY = 0; iY < Size.Height; iY++)
			{
				for (int iX = 0; iX < Size.Width; iX++)
				{
					System.Drawing.Color color = Pixels[iX, iY];
					data.AddRange(new byte[] { color.R, color.G, color.B, color.A });
				}
			}

			return new SceneInternalResource
			{
				Type = "Image",
				ID = ID,
				KVs =
				{
					{
						"data",	Variant.FromDictionary(
							new Dictionary<Variant, Variant>{
								{ Variant.FromPrimitive("width"), Variant.FromPrimitive(Size.Width) },
								{ Variant.FromPrimitive("height"), Variant.FromPrimitive(Size.Height) },
								{ Variant.FromPrimitive("format"), Variant.FromPrimitive("RGBA8") },
								{ Variant.FromPrimitive("data"), Variant.FromPrimitiveArray(data.ToArray()) }
							}
						)
					}
				}
			};
		}
	}
}
