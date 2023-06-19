using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public abstract class ParametrizedFilter : IFilter
    {
        IParametrs parametrs;
        public ParametrizedFilter(IParametrs parametrs)
        {
            this.parametrs = parametrs; 
        }

        public ParameterInfo[] GetParameters()
        {
            return parametrs.GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            this.parametrs.SetValues(values);
            return Process(original, parametrs);
        }
        public abstract Photo Process(Photo original, IParametrs parametrs);
    }
}
