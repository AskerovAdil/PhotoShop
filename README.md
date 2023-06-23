# Simple PhotoShop
Training project, delegation is implemented in the project using the example of creating filters. In Data/Photos.cs, the picture is represented as a set of Pixels[,], where Pixels have the value of the channel c (c=0 - red, c=1 - green, c=2 - blue) pixels
with the x,y coordinate. The value is in the range from 0 to 1.

### Demo client
<img src="https://github.com/AskerovAdil/PhotoShop/blob/main/DemoPh.gif" />

# Пример создания фильтров:
<pre><code class="language-csharp">
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
</code></pre>

## Authors

* **Askerov Adil** - *.NET Developer* - [Askerov Adil](https://github.com/AskerovAdil) - *API Server*
