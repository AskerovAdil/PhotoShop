using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Data
{
    public class Pixel
    {

        private double Check(double value)
        {
            if (value < 0 || value > 1) throw new ArgumentException();
            return value;
        }

        private double red;
        public double R
        {

            get { return red; }
            set
            {
                red = Check(value);
            }
        }
        private double green;
        public double G
        {
            get { return green; }
            set
            {
                green = Check(value);
            }
        }

        private double blue;
        public double B
        {
            get { return blue; }
            set
            {
                blue = Check(value);
            }
        }
    }
}
