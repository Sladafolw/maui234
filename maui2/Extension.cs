using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui2
{
    internal static class Extension
    {
        public static List<Point> Normalize(this List<Point> points)
        {
            var xScale = 200 / points.Max(p => Math.Abs(p.X)) / 2;
            var yScale = 200 / points.Max(p => Math.Abs(p.Y)) / 2;
            return points.Select(p => new Point(p.X * xScale + 200 / 2, 200 / 2 - (p.Y * yScale))).ToList();
        }
      
    }
}
