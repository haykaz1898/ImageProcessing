using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class GaussianBlur : Filter
    {
        public override double[,] Data { get; set; } =
        { { 1,  4,   6, 4, 1 },
          { 4, 16, 24, 16, 4 },
          { 6, 24, 36, 24, 6 },
          { 4, 16, 24, 16, 4 },
          { 1, 4,   6,  4, 1 }
        };
        public override int Division { get; set; } = 256;
        public override int Offset { get; set; } = 0;
        public override FilterType Type { get; set; } = FilterType.Gaussian_Blur;
    }
}
