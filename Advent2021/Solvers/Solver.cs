using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021.Solvers
{
	public abstract class Solver
	{
		protected abstract object Part1(string[] lines);
		protected abstract object Part2(string[] lines);
		
		public object Solve(string[] lines, int part)
		{
			return part == 1 ? Part1(lines) : Part2(lines);
		}
	}
}
