using System;
using System.Linq;
using Rectangle.Impl;

namespace Rectangle
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
            List<Point> points = new List<Point>
            {
                new Point{X=1,Y=4 },
                new Point{X=3,Y=2 },
                new Point{X=1,Y=10 },
                new Point{X=-1,Y=3 },
                new Point{X=2,Y=-4 },
                new Point{X=1,Y=-4 }
            };
            FindRectangle(points);

            Console.ReadKey();
		}
	}
}
