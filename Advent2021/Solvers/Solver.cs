using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021.Solvers
{
	public abstract class Solver
	{
		protected abstract string Part1(string[] lines);
		protected abstract string Part2(string[] lines);
		
		public string Solve(string[] lines, int part)
		{
			return part == 1 ? Part1(lines) : Part2(lines);
		}
	}
}
