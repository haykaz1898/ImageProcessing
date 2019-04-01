using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public interface IFilterFactory
    {
        Filter Create(FilterType type);
    }
}
