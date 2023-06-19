using MyPhotoshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public abstract class PixelFilter : ParametrizedFilter
    {
        protected PixelFilter(IParametrs parametrs) : base(parametrs)
        {
        }

        public abstract Pixel ProcessPixel(Pixel original, IParametrs parametrs);

        public override Photo Process(Photo original, IParametrs parameters)
        {
            var result = new Photo(original.width, original.height);

            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    result[x, y] = ProcessPixel(original[x, y], parameters);
                }
            return result;
        }


  
    }
}
