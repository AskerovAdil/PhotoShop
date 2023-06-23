﻿using MyPhotoshop.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    /*
     - TransformFilter должен принимать в конструкторе sizeTransform (функцию, превращающую старый размер в новый) и
      pointTransform (функция, показывающая, из какой точки старого изображения брать новую)
     */
    public class TransformFilter : ParametrizedFilter<EmptyParameters>
    {
        string name;
        Func<Size, Size> sizeTransform;
        Func<Point,Size, Point> pointTransform;

        public TransformFilter(string name, Func<Size, Size> sizeTransform, Func<Point, Size, Point> pointTransform)
        {
            this.name = name;
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        public override Photo Process(Photo original, EmptyParameters parametrs)
        {
            var oldSize = new Size(original.width, original.height);
            var newSize = sizeTransform(oldSize);
            var result = new Photo(newSize.Width, newSize.Height);
            for(int x=0; x<newSize.Width; x++)
            {
                for(int y=0; y<newSize.Height; y++)
                {
                    var point = new Point(x,y);
                    var oldPoint = pointTransform(point, oldSize);
                    result[x, y] = original[oldPoint.X, oldPoint.Y];
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