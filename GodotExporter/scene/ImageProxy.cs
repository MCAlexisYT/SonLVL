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
		public byte[] Pixels;
		public ColorPalette Palette;
		public Size Size;

		public ImageProxy(int width, int height)
		{
			Pixels = new byte[width * height];
			Size = new Size(width, height);
		}

		public ImageProxy(Size size)
		{
			Pixels = new byte[size.Width * size.Height];
			Size = new Size(size);
		}

		public ImageProxy(int width, int height, ColorPalette palette) : base(width, height)
		{
			Palette = new ColorPalette(palette);
		}

		public ImageProxy(Size size, ColorPalette palette) : base(size)
		{
			Palette = new ColorPalette(palette);
		}

		public static ImageProxy FromAllChunks(bool is_priority)
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
			int width = (is_s2) ? 128 : 256;
			int height = LevelData.ChunkSprites.Length * width;
			ImageProxy img = new ImageProxy(width, height);
			for (int i = 0; i < LevelData.ChunkSprites.Length; i++)
			{
				ImageProxy chunk = FromChunk(i, is_priority);

			}
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

			BitmapBits bits = new BitmapBits((is_s2) ? 128 : 256, (is_s2) ? 128 : 256);

			if (is_priority)
			{
				bits.DrawSpriteHigh(LevelData.ChunkSprites[chunk_index_index]);
			}
			else
			{
				bits.DrawSpriteLow(LevelData.ChunkSprites[chunk_index]);
			}
			
			ColorPalette pal = new ColorPalette();
			for (int line = 0; line < 4; line++)
			{
				for (int index = 0; index < 16; index++)
				{
					pal.Entries[line * 16 + index] = LevelData.GdExportPaletteToColor(line, index);
				}
			}
			
			ImageProxy img = new ImageProxy((is_s2) ? 128 : 256, (is_s2) ? 128 : 256, pal);

			Array.Copy(bits.Bits, img.Pixels, img.Pixels.Length);

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
					System.Drawing.Color color = Palette.Entries[Pixels[iY * Size.Width + iX]];
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
							new Dictionary<string, Variant>{
								{ "width", Variant.FromPrimitive(Size.Width) },
								{ "height", Variant.FromPrimitive(Size.Height) },
								{ "format", Variant.FromPrimitive("RGBA8") },
								{ "data", Variant.FromPrimitiveArray(data.ToArray()) }
							}
						)
					}
				}
			};
		}
	}
}
