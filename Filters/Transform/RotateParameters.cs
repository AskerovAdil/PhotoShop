using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class RotateParameters : IParametrs
    {
        public double Angle;


        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo { Name="Угол", MaxValue=360, MinValue=0, Increment=5, DefaultValue=0 }

            };
        }

        public void SetValues(double[] doubles)
        {
            Angle = doubles[0];
        }
    }
}
