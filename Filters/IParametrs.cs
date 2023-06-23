using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public interface IParametrs
    {
        ParameterInfo[] GetDescription();
        void SetValues(double[] doubles);
    }
}
