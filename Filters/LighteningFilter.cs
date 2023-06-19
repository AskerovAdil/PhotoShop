using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter<LighteningParameters>
	{

        public override string ToString ()
		{
			return "Осветление/затемнение";
		}

		public override Pixel ProcessPixel(Pixel original, LighteningParameters parametrs)
		{
			var resultPixel = original * parametrs.Coefficient;
			return resultPixel;
		}

    }
}

