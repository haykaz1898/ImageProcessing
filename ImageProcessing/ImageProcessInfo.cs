using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
namespace ImageProcessing
{
    public class ImageProcessInfo
    {
        public int StartPosition;
        public int FinishPosition;
        public Color[,] Colors;
        public Filter Filter;
        public ImageProcessInfo(int startPosition, int finishPosition,Color[,] colors,Filter filter)
        {
            StartPosition = startPosition;
            FinishPosition = finishPosition;
            Colors = colors;
            Filter = filter;
        }
    }
}
