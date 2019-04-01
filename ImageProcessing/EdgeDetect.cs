using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class EdgeDetect : Filter
    {
        public override double[,] Data { get; set; } =
        { {  0,  1,  0},
          {  1, -4,  1},
          {  0,  1,  0},
        };

        public override int Division { get; set; } = 50;
        public override int Offset { get; set; } = 0;
        public override FilterType Type { get; set; } = FilterType.Edge_Detect;
    }
}
