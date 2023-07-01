using MyPhotoshop.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class TransformFilter<TParametrs> : ParametrizedFilter<TParametrs>
        where TParametrs : IParametrs, new() 
    {
        string name;
        Func<Size, TParametrs, Size> sizeTransform;
        Func<Point, Size, TParametrs, Point?> pointTransform;

        public TransformFilter(string name, Func<Size, TParametrs, Size> sizeTransform, Func<Point, Size, TParametrs, Point?> pointTransform)
        {
            this.name = name;
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        public override Photo Process(Photo original, TParametrs parametrs)
        {
            var oldSize = new Size(original.width, original.height);
            var newSize = sizeTransform(oldSize, parametrs);
            var result = new Photo(newSize.Width, newSize.Height);
            for(int x=0; x<newSize.Width; x++)
            {
                for(int y=0; y<newSize.Height; y++)
                {
                    var point = new Point(x,y);
                    var oldPoint = pointTransform(point, oldSize, parametrs);
                    if(oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            }
            return result;

        }

        public override string ToString()
        {
            return name;
        }



    }
}
