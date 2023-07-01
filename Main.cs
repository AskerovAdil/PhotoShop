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

            Func<Size, RotateParameters, Size> sizeRotator = (size, parametrs) =>
            {
                var angle = Math.PI * parametrs.Angle / 180;
                return new Size(
                    (int)(size.Width * Math.Abs(Math.Cos(angle)) + size.Height * Math.Abs(Math.Sin(angle))),
                    (int)(size.Height * Math.Abs(Math.Cos(angle)) + size.Width * Math.Abs(Math.Sin(angle))));
            };


            Func<Point, Size, RotateParameters, Point?> pointRotator = (point, oldSize, parametrs) =>
            {
                var newSize = sizeRotator(oldSize, parametrs);
                var angle = Math.PI * parametrs.Angle / 180;
                point = new Point(point.X - newSize.Width/2, point.Y - newSize.Height/2);
                var x = oldSize.Width / 2 +(int)(point.X*Math.Cos(angle)+point.Y*Math.Sin(angle));
                var y = oldSize.Height / 2 + (int)(-point.X * Math.Sin(angle) + point.Y * Math.Cos(angle));

                if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                    return null;
                return new Point(x, y);

            };

            window.AddFilter(new TransformFilter<RotateParameters>
                ("Свободное вращение", sizeRotator, pointRotator));

   

            /*			window.AddFilter(new TransformFilter(
                            "Отразить по горизонтали",
                            size=>size,
                            (oldPoint, oldSize) => new Point(oldSize.Width - oldPoint.X - 1, oldPoint.Y) 
                            ));
                        window.AddFilter(new TransformFilter(
                            "Повернуть по часовой стрелке",
                            size => new Size(size.Height,size.Width),
                            (oldPoint, oldSize) => new Point(oldPoint.Y, oldPoint.X)
                            ));
            */

            Application.Run (window);
		}
	}
}
