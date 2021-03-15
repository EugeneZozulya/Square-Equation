using System;

namespace SquareEquation
{
    /// <summary>
    /// Square equation.
    /// </summary>
    public static class SQEquation
    {
        /// <summary>
        /// Searching roots of the square equation.
        /// </summary>
        /// <param name="a"> The first coefficient. </param>
        /// <param name="b"> The second coefficient. </param>
        /// <param name="c"> The third coefficient. </param>
        /// <returns> Roots of square equation. </returns>
        public static (double, double, string, string) SearchRoots(double a, double b, double c)
        {
            double x1 = default, x2 = default, disc = default;
            string complexX1 = null, complexX2 = null;
            disc = b * b - 4 * a * c;
            if(disc>0)
            {
                x1 = (-b + Math.Sqrt(disc)) / (2 * a);
                x2 = (-b - Math.Sqrt(disc)) / (2 * a);
            }
            else if(disc == 0)
            {
                x1 = -b / (2 * a);
                x2 = x1;
            }
            else
            {
                disc = Math.Abs(disc);
                double complex = Math.Round((Math.Sqrt(disc) / (2 * a)),3);
                double num = Math.Round(Math.Abs(b) / (2*a),2);
                complexX1 = $"{num.ToString()} + i·{complex.ToString()}";
                complexX2 = complexX1;
                complexX2 = complexX2.Replace('+', '-');
            }
            return (Math.Round(x1,3), Math.Round(x2,3), complexX1,complexX2);
        }
    }
}
