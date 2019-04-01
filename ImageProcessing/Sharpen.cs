using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class Sharpen : Filter
    {
        public override double[,] Data { get; set; } =
        { { 0,  0, 0,  0, 0 },
          { 0,  0, 5,  0, 0 },
          { 0, -1, 5, -1, 0 },
          { 0,  0, 1,  0, 0 },
          { 0,  0, 0,  0, 0 }
        };

        public override int Division { get; set; } = 1;
        public override int Offset { get; set; } = 0;
        public override FilterType Type { get; set; } = FilterType.Sharpen;
    }
}
