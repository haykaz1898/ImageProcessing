﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
namespace ImageProcessing
{
    public interface IColorArrayToBitmapConverter
    {
        Bitmap Convert(Color[,] colors);
    }
}
