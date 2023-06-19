using MyPhotoshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class PixelFilter<TParametrs> : ParametrizedFilter<TParametrs>
        where TParametrs : IParametrs, new()
    {
        string name;
        Func<Pixel, TParametrs, Pixel> proccessor;

        public PixelFilter(string name, Func<Pixel, TParametrs, Pixel> proccessor)
        {
            this.name = name;
            this.proccessor = proccessor;
        }

        public override Photo Process(Photo original, TParametrs parameters)
        {
            var result = new Photo(original.width, original.height);

            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    result[x, y] = proccessor(original[x, y], parameters);
                }
            return result;
        }

        public override string ToString()
        {
            return name;
        }



    }
}
