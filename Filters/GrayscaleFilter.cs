﻿using MyPhotoshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class GrayscaleFilter : PixelFilter
    {
        public GrayscaleFilter() : base(new EmptyParameters())
        {
        }

        public override string ToString()
        {
            return "Оттенок серого";
        }

        public override Pixel ProcessPixel(Pixel original, IParametrs parametrs)
        {
            var lightness = original.R + original.G + original.B;
            lightness /= 3;

            return new Pixel() { R = lightness, G = lightness, B = lightness };
        }
    }
}
