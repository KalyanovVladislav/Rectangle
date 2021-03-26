using System;
using System.Collections.Generic;
using System.Linq;
using Rectangle.Impl;

namespace Rectangle.Console
{
    class Program
    {
        /// <summary>
        /// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
        /// See TODO.txt file for task details.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>
            {
                new Point{X=5,Y=4},
                new Point{X=5,Y=5 },
                //new Point{X=-5,Y=-7 },
                new Point{X=-5,Y=4 },
                new Point{X=-5,Y=5 },
                new Point{X=-5,Y=-7 },
                new Point{X=6,Y=-7 },
                new Point{X=3,Y=-2 }
            };
            try
            {
                var rectangle = Service.FindRectangle(points);
                System.Console.WriteLine("Rectangle :\n " +
                    "X={0}  Y={1}\n" +
                    "Height = {2}  Width={3}",
                    rectangle.X, rectangle.Y, rectangle.Height, rectangle.Width);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            System.Console.ReadKey();
        }
    }
}
