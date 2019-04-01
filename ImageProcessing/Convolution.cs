using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    public class Convolution
    {
        public static void Process(ImageProcessInfo info,Color[,] result)
        {
            
            int height = info.Colors.GetLength(0);
            int width = info.Colors.GetLength(1);
            //Color[,] result = new Color[height, width];
            for (int x = info.StartPosition; x <= info.FinishPosition; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    double red = 0,
                           green = 0,
                           blue = 0;
                    for (int i = 0; i < info.Filter.Size; i++)
                    {
                        for (int j = 0; j < info.Filter.Size; j++)
                        {
                            if ((x + i < height && y + j < width))
                            {
                              var color = info.Colors[x + i, y + j];
                              red += color.R * info.Filter[i, j];
                              green += color.G * info.Filter[i, j];
                              blue += color.B * info.Filter[i, j];
                            }
                        }
                    }
                    if (x < height && y < width)
                    result[x, y] = Color.FromArgb(255, Filter.Normalize(red, info.Filter),
                                                            Filter.Normalize(green, info.Filter),
                                                            Filter.Normalize(blue, info.Filter));
                }
            }


            //return result;
        }
    }
}
