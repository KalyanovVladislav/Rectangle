using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	public class Tests
	{
		List<Point> validList;
		List<Point> invalidList;

		[SetUp]
		public void Setup()
		{
			validList = new List<Point>
			{
				new Point{X=5,Y=-5 },
				new Point{X=-5,Y=-5 },
				new Point{X=5,Y=5 },
				new Point{X=-4,Y=5 }
			};

			invalidList = new List<Point>
			{
				new Point{X=5,Y=-5 },
				new Point{X=-5,Y=-5 },
				new Point{X=5,Y=5 },
				new Point{X=-5,Y=5 }
			};
		}

		[Test]
		public void ValidListTest()
		{
			var rectangle = Service.FindRectangle(validList);
			Assert.IsNotNull(rectangle);
		}

		[Test]
		public void NullListTest()
		{
			validList = null;
			Assert.Throws<ArgumentNullException>(() => Service.FindRectangle(validList));
		}

		[Test]
		public void ListMinimumCountTest()
		{
			validList.Clear();
			validList.Add(new Point { X = 5, Y = -5 });
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(validList));
		}

		[Test]
		public void InvalidListTest()
		{
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(invalidList));
		}

		[Test]
		public void DuplicatePointsTest()
		{
			validList.Add(validList[0]);
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(validList));
		} 
	}
}