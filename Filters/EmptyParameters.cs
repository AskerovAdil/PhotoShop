using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{

    public class EmptyParameters : IParametrs
    {
        public double Coefficient;


        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[]
            {

            };
        }

        public void SetValues(double[] doubles)
        {
        }
    }
}
