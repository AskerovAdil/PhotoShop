using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using System;
using System.Drawing;
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

			window.AddFilter(new TransformFilter(
				"Отразить по горизонтали",
				size=>size,
				(oldPoint, oldSize) => new Point(oldSize.Width - oldPoint.X - 1, oldPoint.Y) 
				));
            window.AddFilter(new TransformFilter(
				"Повернуть по часовой стрелке",
				size => new Size(size.Height,size.Width),
				(oldPoint, oldSize) => new Point(oldPoint.Y, oldPoint.X)
				));


            Application.Run (window);
		}
	}
}
