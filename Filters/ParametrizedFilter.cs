using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{

    public abstract class ParametrizedFilter<TParametrs> : IFilter
        where TParametrs : IParametrs, new()
    {
        public ParameterInfo[] GetParameters()
        {
            return new TParametrs().GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parametrs = new TParametrs();
            parametrs.SetValues(values);
            return Process(original, parametrs);
        }
        public abstract Photo Process(Photo original, TParametrs parametrs);
    }
}
