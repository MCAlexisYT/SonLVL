using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SonicRetro.SonLVL.GodotExporter.Variant;
using SystemColor = System.Drawing.Color;

namespace SonicRetro.SonLVL.GodotExporter.scene
{
	public class ImageProxy
	{
		public byte[] Pixels;
		public SystemColor[] Palette;
		public Size Size;

		public ImageProxy(int width, int height)
		{
			Pixels = new byte[width * height];
			Size = new Size(width, height);
		}

		public ImageProxy(Size size)
		{
			Pixels = new byte[size.Width * size.Height];
			Size = size;
		}

		public ImageProxy(int width, int height, SystemColor[] palette)
		{
			Palette = palette;
		}

		public ImageProxy(Size size, SystemColor[] palette)
		{
			Palette = palette;
		}

		public static ImageProxy FromAllChunks(bool is_priority)
		{
			Size chunk_size = new Size(LevelData.Level.ChunkWidth, LevelData.Level.ChunkHeight);
			int img_height = LevelData.ChunkSprites.Count * chunk_size.Width;

			SystemColor[] pal = new SystemColor[64];
			for (int line = 0; line < 4; line++)
			{
				for (int index = 0; index < 16; index++)
				{
					pal[line * 16 + index] = LevelData.GdExportPaletteToColor(line, index);
				}
			}

			ImageProxy img = new ImageProxy(chunk_size.Width, img_height, pal);
			for (int i = 0; i < LevelData.ChunkSprites.Count; i++)
			{
				ImageProxy chunk = FromChunk(i, is_priority);
				for (int iX = 0; iX < chunk_size.Width; iX++)
				{
					for (int iY = 0; iY < chunk_size.Height; iY++)
					{
						img.SetPixel(iX, iY + chunk_size.Height * i, chunk.GetPixel(iX, iY));
					}
				}
			}
			return img;
		}

		public static ImageProxy FromBackgroundChunks()
		{
			Size chunk_size = new Size(LevelData.Level.ChunkWidth, LevelData.Level.ChunkHeight);
			int img_height = LevelData.ChunkSprites.Count * chunk_size.Width;

			SystemColor[] pal = new SystemColor[64];
			for (int line = 0; line < 4; line++)
			{
				for (int index = 0; index < 16; index++)
				{
					pal[line * 16 + index] = LevelData.GdExportPaletteToColor(line, index);
				}
			}

			ImageProxy img = new ImageProxy(chunk_size.Width, img_height, pal);
			for (int i = 0; i < LevelData.ChunkSprites.Count; i++)
			{
				ImageProxy chunk = ImageProxy.FromBackgroundChunk(i);
				for (int iX = 0; iX < chunk_size.Width; iX++)
				{
					for (int iY = 0; iY < chunk_size.Height; iY++)
					{
						img.SetPixel(iX, iY + chunk_size.Height * i, chunk.GetPixel(iX, iY));
					}
				}
			}
			return img;
		}

		public static ImageProxy FromBackgroundChunk(int chunk_index)
		{
			Size chunk_size = new Size(LevelData.Level.ChunkWidth, LevelData.Level.ChunkHeight);

			BitmapBits bits = new BitmapBits(chunk_size);

			bits.DrawSprite(LevelData.ChunkSprites[chunk_index]);
			SystemColor[] pal = new SystemColor[64];
			for (int line = 0; line < 4; line++)
			{
				for (int index = 0; index < 16; index++)
				{
					pal[line * 16 + index] = LevelData.GdExportPaletteToColor(line, index);
				}
			}

			ImageProxy img = new ImageProxy(chunk_size, pal);

			for (int iX = 0; iX < chunk_size.Width; iX++)
			{
				for (int iY = 0; iY < chunk_size.Height; iY++)
				{
					img.SetPixel(iX, iY, bits.Bits[bits.GetPixelIndex(iX, iY)]);
				}
			}
			return img;
		}

		public static ImageProxy FromChunk(int chunk_index, bool is_priority)
		{
			Size chunk_size = new Size(LevelData.Level.ChunkWidth, LevelData.Level.ChunkHeight);

			BitmapBits bits = new BitmapBits(chunk_size);

			if (is_priority)
			{
				bits.DrawSpriteHigh(LevelData.ChunkSprites[chunk_index]);
			}
			else
			{
				bits.DrawSpriteLow(LevelData.ChunkSprites[chunk_index]);
			}
			SystemColor[] pal = new SystemColor[64];
			for (int line = 0; line < 4; line++)
			{
				for (int index = 0; index < 16; index++)
				{
					pal[line * 16 + index] = LevelData.GdExportPaletteToColor(line, index);
				}
			}
			
			ImageProxy img = new ImageProxy(chunk_size, pal);

			for (int iX = 0; iX < chunk_size.Width; iX++)
			{
				for (int iY = 0; iY < chunk_size.Height; iY++)
				{
					img.SetPixel(iX, iY, bits.Bits[bits.GetPixelIndex(iX, iY)]);
				}
			}
			return img;
		}

		public string ID;

		public byte GetPixel(int x, int y)
		{
			return Pixels[(x * Size.Width) + y];
		}

		public byte GetPixel(Point coord)
		{
			return GetPixel(coord.X, coord.Y);
		}

		public void SetPixel(int x, int y, byte value)
		{
			Pixels[(x * Size.Width) + y] = value;
		}

		public void SetPixel(Point coord, byte value)
		{
			SetPixel(coord.X, coord.Y, value);
		}

		public SceneInternalResource ToResource()
		{
			List<byte> data = new List<byte>();

			for (int iY = 0; iY < Size.Height; iY++)
			{
				for (int iX = 0; iX < Size.Width; iX++)
				{
					SystemColor color = Palette[Pixels[iY * Size.Width + iX]];
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
