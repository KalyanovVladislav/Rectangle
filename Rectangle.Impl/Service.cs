using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
    public static class Service
    {
		#region PRIVATE_FIELDS
        private static bool isPointExcluded = false; //flag to determine if point has been excluded
		#endregion
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static Rectangle FindRectangle(List<Point> points)
        {
            Rectangle rectangle = new Rectangle();
            isPointExcluded = false;

            #region VALIDATION
            //"points" argument shouldn't be null
            if (points is null)
            {
                throw new ArgumentNullException("points", "the 'points' parameter is null");
            }

            //"points" should contain at least 2 points
            if (points.Count < Constants.MINIMUM_NUMBER_OF_POINTS)
            {
                throw new ArgumentException("points", $"minimum number of elements is {Constants.MINIMUM_NUMBER_OF_POINTS}");
            }

            //There shouldn't be points with a same coordinates
            if (points.GroupBy(x => x, new PointEqualityComparer()).Any(g => g.Count() > 1))
            {
                throw new ArgumentException("points", "the 'points' parameter contains duplicates");
            }
            #endregion

            IEnumerable<int> listOfX = points.Select(p => p.X);
            IEnumerable<int> listOfY = points.Select(p => p.Y);

            int maxX = GetMax(listOfX);
            int minX = GetMin(listOfX);

            int maxY = GetMax(listOfY);
            int minY = GetMin(listOfY);

            rectangle.X = minX;
            rectangle.Y = maxY;
            rectangle.Height = maxY-minY;
            rectangle.Width = maxX-minX;

            //if no rectangle is found, an exception is thrown
            if (isPointExcluded == false)
            {
                throw new ArgumentException("points", "the input list is invalid, rectangle not found");
            }

            return rectangle;

        }

        #region HELPERS
        /// <summary>
        /// returns the maximum element if it is not unique or if one element has already been excluded 
        /// otherwise returns the element before the maximum element , excludes one element and set 'isPointExcluded' to true
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private static int GetMax(IEnumerable<int> points)
        {
            int max = points.Max();

            if (isPointExcluded == false)
            {
                if (points.Where(p=>p == max).Count() == 1)
                {
                    isPointExcluded = true;
                    max = points.OrderByDescending(p=>p).ElementAt(1);
                }
            }  
            return max;
        }

        /// <summary>
        /// returns the minimum element if it is not unique or if one element has already been excluded 
        /// otherwise returns the element after the minimum element , excludes one element and set 'isPointExcluded' to true
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private static int GetMin(IEnumerable<int> points)
        {
            int min = points.Min();

            if (isPointExcluded == false)
            {
                if (points.Where(p => p == min).Count() == 1)
                {
                    isPointExcluded = true;
                    min = points.OrderBy(p => p).ElementAt(1);
                }
            }

            return min;
        }
        //comparator for comparing Point objects to determine duplicates
        private class PointEqualityComparer : IEqualityComparer<Point>
        {
            public bool Equals(Point p1, Point p2)
            {
                if (p1 == null && p2 == null)
                    return true;
                else if (p1 == null || p2 == null)
                    return false;
                else if (p1.X == p2.X && p1.Y == p2.Y)
                    return true;
                else
                    return false;
            }

            public int GetHashCode(Point p)
            {
                int hCode = p.X ^ p.Y;
                return hCode.GetHashCode();
            }
        }
        #endregion
    }
}
