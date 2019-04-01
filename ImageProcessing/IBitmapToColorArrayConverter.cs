using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ImageProcessing
{
    public interface IBitmapToColorArrayConverter
    {
        Color[,] Convert(Bitmap bitmap);
        
    }
}
