using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021.Solvers
{
	public sealed class Day1 : Solver
	{
		protected override object Part1(string[] lines)
		{
			var ints = lines.Select(s => int.Parse(s)).ToArray();
			var count = 0;

			for (int i = 0; i < ints.Length - 1; i++)
			{
				if (ints[i + 1] > ints[i])
				{
					count++;
				}
			}

			return count;
		}

		protected override object Part2(string[] lines)
		{
			var ints = lines.Select(s => int.Parse(s)).ToArray();
			var sums = new int[ints.Length - 2];

			for (int i = 0; i < ints.Length - 2; i++)
			{
				sums[i] = ints[i] + ints[i + 1] + ints[i + 2];
			}

			var count = 0;

			for (int i = 0; i < sums.Length - 1; i++)
			{
				if (sums[i + 1] > sums[i])
				{
					count++;
				}
			}

			return count;
		}
	}
}
