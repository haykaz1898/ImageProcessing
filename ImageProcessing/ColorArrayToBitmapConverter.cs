using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
namespace ImageProcessing
{
    public class ColorArrayToBitmapConverter : IColorArrayToBitmapConverter
    {
        public Bitmap Convert(Color[,] colors)
        {
            Bitmap bmp = new Bitmap(colors.GetLength(1),colors.GetLength(0));
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte[] bytes = ColorToByteArray(colors);
            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, bmpData.Scan0, bmpData.Stride * bmpData.Height);
            bmp.UnlockBits(bmpData);
            return bmp;
        }

        private byte[] ColorToByteArray(Color[,] colors)
        {
            byte[] res = new byte[colors.Length * 4];
            int k = 0;
            for (int i = 0; i < colors.GetLength(0); i++)
            {
                for (int j = 0; j < colors.GetLength(1); j++)
                {
                    res[k + j + i * colors.GetLength(1)] = colors[i, j].B;
                    res[k + j + i * colors.GetLength(1) + 1] = colors[i, j].G;
                    res[k + j + i * colors.GetLength(1) + 2] = colors[i, j].R;
                    res[k + j + i * colors.GetLength(1) + 3] = colors[i, j].A;
                    k += 3;
                }
            }
            return res;
        }
    }
}
