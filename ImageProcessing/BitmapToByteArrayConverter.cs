using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Media;
namespace ImageProcessing
{
    public class BitmapToColorArrayConverter : IBitmapToColorArrayConverter
    {
        public Color[,] Convert(Bitmap bitmap)
        {
            byte[] bytes = BitmapToByteArray(bitmap);
            Color[,] colors = new Color[bitmap.Height, bitmap.Width];
            int k = 0;

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    colors[i,j] = Color.FromArgb(bytes[k + 3], bytes[k + 2], bytes[k + 1], bytes[k]);
                    k += 4;
                }
            }
            return colors;
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            Bitmap bmp = new Bitmap(bitmap);

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte[] bytes = new byte[bmpData.Stride * bmp.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, bytes, 0, bytes.Length);
            
            bmp.UnlockBits(bmpData);
            return bytes;
        }
    }
}
