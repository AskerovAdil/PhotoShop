using MyPhotoshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class GrayscaleFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[]
            {

            };
        }

        public override string ToString()
        {
            return "Оттенок серого";
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.width, original.height);

            for(int i =0;i< original.width; i++)
            {
                for(int j = 0; j < original.height;j++) 
                {
                    var lightness = original[i, j].R + original[i, j].G + original[i, j].B;
                    lightness /= 3;
                    result[i, j] = new Pixel() { R = lightness, G = lightness, B = lightness };
                }
            }
            return result;
        }
    }
}
