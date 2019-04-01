using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    abstract public class Filter
    {
        abstract public double[,] Data { get; set; }
        abstract public int Division { get; set; }
        abstract public int Offset { get; set; }
        abstract public FilterType Type { get; set; }
        public int Size => Data.GetLength(0);

        public double this[int i, int j] => Data[i, j];
        
        public static byte Normalize(double value, Filter filter)
        {
            return (byte)Math.Min(Math.Max((int)(value / filter.Division + filter.Offset), 0), 255);
        }
    }
    
}
