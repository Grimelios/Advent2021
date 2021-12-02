using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021.Solvers
{
	public sealed class Day2 : Solver
	{
		protected override object Part1(string[] lines)
		{
			var x = 0;
			var y = 0;

			foreach (var s in lines)
			{
				var tokens = s.Split(' ');
				var value = int.Parse(tokens[1]);

				switch (tokens[0])
				{
					case "forward": x += value; break;
					case "up": y -= value; break;
					case "down": y += value; break;
				}
			}

			return x * y;
		}

		protected override object Part2(string[] lines)
		{
			var x = 0;
			var aim = 0;
			var depth = 0;

			foreach (var s in lines)
			{
				var tokens = s.Split(' ');
				var value = int.Parse(tokens[1]);

				switch (tokens[0])
				{
					case "forward":
					{
						x += value;
						depth += aim * value;

						break;
					}

					case "up": aim -= value; break;
					case "down": aim += value; break;
				}
			}

			return x * depth;
		}
	}
}
