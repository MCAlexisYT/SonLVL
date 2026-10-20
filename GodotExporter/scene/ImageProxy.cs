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
		public byte[,] Pixels;
		public ColorPalette Palette;
		public Size Size;

		public ImageProxy(int width, int height)
		{
			Pixels = new byte[width, height];
			Size = new Size(width, height);
		}

		public ImageProxy(Size size)
		{
			Pixels = new byte[size.Width, size.Height];
			Size = new Size(size);
		}

		public static ImageProxy FromChunk(int chunk_index, bool is_priority)
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

			BitmapBits bits = new BitmapBits((is_s2) ? 128 : 256, (is_s2) ? 128 : 256);

			if (is_priority)
			{
				bits.DrawSpriteHigh(LevelData.ChunkSprites[img]);
			}
			else
			{
				bits.DrawSpriteLow(LevelData.ChunkSprites[img]);
			}
			

			return img;
		}

		public string ID;
		public SceneInternalResource ToResource()
		{
			List<byte> data = new List<byte>();

			for (int iY = 0; iY < Size.Height; iY++)
			{
				for (int iX = 0; iX < Size.Width; iX++)
				{
					System.Drawing.Color color = Palette.Entries[Pixels[iX, iY]];
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
