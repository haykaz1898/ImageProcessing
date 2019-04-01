using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class FilterFactory : IFilterFactory
    {
        public Filter Create(FilterType type)
        {
            switch (type)
            {
                case FilterType.Gaussian_Blur:
                    return new GaussianBlur();
                case FilterType.Sharpen:
                    return new Sharpen();
                case FilterType.Edge_Detect:
                    return new EdgeDetect();
                default:
                    throw new Exception("Unsupported Filter");
            }
        }
    }
}
