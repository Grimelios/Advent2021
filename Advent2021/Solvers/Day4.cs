using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021.Solvers
{
	public sealed class Day4 : Solver
	{
		protected override object Part1(string[] lines)
		{
			var numbers = lines[0].Split(',').Select(s => int.Parse(s)).ToArray();
			var boards = new List<Board>();
			var line = 2;

			do
			{
				var grid = new int[5, 5];

				for (int i = 0; i < 5; i++)
				{
					var tokens = lines[line++].Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

					for (int j = 0; j < 5; j++)
					{
						grid[j, i] = int.Parse(tokens[j]);
					}

					boards.Add(new Board(grid));
				}

				line++;
			}
			while (line < lines.Length);

			var set = new HashSet<int>();

			foreach (var n in numbers)
			{
				set.Add(n);

				foreach (var board in boards)
				{
					if (board.Won(set))
					{
						return board.Sum(set) * n;
					}
				}
			}

			return null;
		}

		protected override object Part2(string[] lines)
		{
			var numbers = lines[0].Split(',').Select(s => int.Parse(s)).ToArray();
			var boards = new List<Board>();
			var line = 2;

			do
			{
				var grid = new int[5, 5];

				for (int i = 0; i < 5; i++)
				{
					var tokens = lines[line++].Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

					for (int j = 0; j < 5; j++)
					{
						grid[j, i] = int.Parse(tokens[j]);
					}

					boards.Add(new Board(grid));
				}

				line++;
			}
			while (line < lines.Length);

			var set = new HashSet<int>();

			foreach (var n in numbers)
			{
				set.Add(n);

				for (int i = boards.Count - 1; i >= 0; i--)
				{
					var board = boards[i];

					if (board.Won(set))
					{
						if (boards.Count == 1)
						{
							return board.Sum(set) * n;
						}

						boards.RemoveAt(i);
					}
				}
			}

			return null;
		}

		private sealed class Board
		{
			private int[,] grid;

			public Board(int[,] grid)
			{
				this.grid = grid;
			}

			public bool Won(HashSet<int> set)
			{
				for (int i = 0; i < 5; i++)
				{
					int j;

					for (j = 0; j < 5; j++)
					{
						if (!set.Contains(grid[j, i]))
						{
							break;
						}
					}

					if (j == 5)
					{
						return true;
					}
				}

				for (int i = 0; i < 5; i++)
				{
					int j;

					for (j = 0; j < 5; j++)
					{
						if (!set.Contains(grid[i, j]))
						{
							break;
						}
					}

					if (j == 5)
					{
						return true;
					}
				}

				return false;
			}

			public int Sum(HashSet<int> set)
			{
				var sum = 0;

				for (int i = 0; i < 5; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						if (!set.Contains(grid[j, i]))
						{
							sum += grid[j, i];
						}
					}
				}

				return sum;
			}
		}
	}
}
