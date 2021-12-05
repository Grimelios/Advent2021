using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021.Solvers
{
	public sealed class Day5 : Solver
	{
		protected override object Part1(string[] lines)
		{
			var xMax = 0;
			var yMax = 0;
			var points = new List<Point>();

			foreach (var s in lines)
			{
				var tokens = s.Split(' ');
				var p0 = tokens[0].Split(',');
				var p1 = tokens[2].Split(',');
				var x0 = int.Parse(p0[0]);
				var y0 = int.Parse(p0[1]);
				var x1 = int.Parse(p1[0]);
				var y1 = int.Parse(p1[1]);

				if (!(x0 == x1 || y0 == y1))
				{
					continue;
				}

				points.Add(new Point(x0 - 1, y0 - 1));
				points.Add(new Point(x1 - 1, y1 - 1));
				xMax = Math.Max(Math.Max(x0, x1), xMax);
				yMax = Math.Max(Math.Max(y0, y1), yMax);
			}

			var grid = new int[xMax, yMax];

			for (int i = 0; i < points.Count; i += 2)
			{
				var p0 = points[i];
				var p1 = points[i + 1];
				var x0 = Math.Min(p0.X, p1.X);
				var x1 = Math.Max(p0.X, p1.X);
				var y0 = Math.Min(p0.Y, p1.Y);
				var y1 = Math.Max(p0.Y, p1.Y);
				
				for (int y = y0; y <= y1; y++)
				{
					for (int x = x0; x <= x1; x++)
					{
						grid[x, y]++;
					}
				}
			}

			var sum = 0;

			for (int i = 0; i < yMax; i++)
			{
				for (int j = 0; j < xMax; j++)
				{
					if (grid[j, i] >= 2)
					{
						sum++;
					}
				}
			}

			return sum;
		}

		protected override object Part2(string[] lines)
		{
			var xMax = 0;
			var yMax = 0;
			var points = new List<Point>();

			foreach (var s in lines)
			{
				var tokens = s.Split(' ');
				var p0 = tokens[0].Split(',');
				var p1 = tokens[2].Split(',');
				var x0 = int.Parse(p0[0]);
				var y0 = int.Parse(p0[1]);
				var x1 = int.Parse(p1[0]);
				var y1 = int.Parse(p1[1]);

				points.Add(new Point(x0 - 1, y0 - 1));
				points.Add(new Point(x1 - 1, y1 - 1));
				xMax = Math.Max(Math.Max(x0, x1), xMax);
				yMax = Math.Max(Math.Max(y0, y1), yMax);
			}

			var grid = new int[xMax, yMax];

			for (int i = 0; i < points.Count; i += 2)
			{
				var p0 = points[i];
				var p1 = points[i + 1];
				var steps = Point.Steps(p0, p1);

				for (int step = 0; step <= steps; step++)
				{
					var p = Point.Lerp(p0, p1, step);
					
					grid[p.X, p.Y]++;
				}
			}

			var sum = 0;

			for (int i = 0; i < yMax; i++)
			{
				for (int j = 0; j < xMax; j++)
				{
					if (grid[j, i] >= 2)
					{
						sum++;
					}
				}
			}

			return sum;
		}

		[DebuggerDisplay("X={X}, Y={Y}")]
		private sealed class Point
		{
			public static Point Lerp(Point p0, Point p1, int steps)
			{
				var xStep = Math.Sign(p1.X - p0.X);
				var yStep = Math.Sign(p1.Y - p0.Y);

				return new Point(p0.X + xStep * steps, p0.Y + yStep * steps);
			}

			public static int Steps(Point p0, Point p1)
			{
				var dX = Math.Abs(p0.X - p1.X);
				var dY = Math.Abs(p0.Y - p1.Y);

				return Math.Max(dX, dY);
			}

			public Point(int x, int y)
			{
				X = x;
				Y = y;
			}

			public int X { get; }
			public int Y { get; }
		}
	}
}