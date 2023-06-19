using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using System;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new PixelFilter<LighteningParameters>(
				"Осветление/затемнение",
				(pixel, parametrs) => pixel * parametrs.Coefficient
				));
            window.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенок серого",
                (original, parametrs) =>
				{
                    var lightness = original.R + original.G + original.B;
                    lightness /= 3;

                    return new Pixel() { R = lightness, G = lightness, B = lightness };
                }
				));

			Application.Run (window);
		}
	}
}
