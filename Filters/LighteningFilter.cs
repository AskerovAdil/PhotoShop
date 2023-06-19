using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter
	{
        public LighteningFilter() : base(new LighteningParameters())
        {
        }

        public override string ToString ()
		{
			return "Осветление/затемнение";
		}

		public override Pixel ProcessPixel(Pixel original, IParametrs parametrs)
		{
			var resultPixel = original * (parametrs as LighteningParameters).Coefficient;
			return resultPixel;
		}


    }
}

