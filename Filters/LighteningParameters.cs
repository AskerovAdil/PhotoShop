using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class LighteningParameters : IParametrs
    {
        public double Coefficient;


        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo { Name="Коэффициент", MaxValue=10, MinValue=0, Increment=0.1, DefaultValue=1 }

            };
        }

        public void SetValues(double[] doubles)
        {
            Coefficient= doubles[0];
        }
    }
}
