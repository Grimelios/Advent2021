using System;
using System.IO;
using Advent2021.Solvers;

namespace Advent2021
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			const string Invalid = "[invalid input]";

			string s;

			do
			{
				Console.Write("Enter puzzle: ");

				s = Console.ReadLine().Trim();

				var tokens = s.Split('.');
				var day = 0;
				var parts = 3;

				if (tokens.Length == 1)
				{
					if (!int.TryParse(s, out day) || day < 1 || day > 25)
					{
						Console.WriteLine(Invalid);
					}
				}
				else if (tokens.Length == 2)
				{
					if (!int.TryParse(tokens[0], out day) || day < 1 || day > 25 ||
						!int.TryParse(tokens[1], out parts) || parts < 1 || parts > 2)
					{
						Console.WriteLine(Invalid);
					}
				}
				else
				{
					Console.WriteLine(Invalid);
				}

				if (day >= 1 && day <= 25)
				{
					var solver = (Solver)Activator.CreateInstance(Type.GetType($"Advent2021.Solvers.Day{day}, " +
						"Advent2021"));
					var lines = File.ReadAllLines($"Data/Day{day}.txt");

					if (lines.Length == 0)
					{
						Console.WriteLine("[empty input]");
					}
					else
					{
						void Solve(int part)
						{
							Console.Write($"Part {part}: ");

							try
							{
								Console.WriteLine(solver.Solve(lines, part));
							}
							catch (NotImplementedException)
							{
								Console.WriteLine("[not implemented]");
							}
						}

						if (parts % 2 == 1)
						{
							Solve(1);
						}

						if (parts >= 2)
						{
							Solve(2);
						}
					}
				}
			}
			while (s != "q" && s != "quit" && s != "exit");
		}
	}
}
