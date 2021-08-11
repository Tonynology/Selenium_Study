using System;

namespace Calculator
{
    public class Calc
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Sub(double a, double b)
        {
            return a - b;
        }
        public double AreaOfCircle(int radius)
        {
            return (22 / 7) * radius * radius;
        }
    }
}
