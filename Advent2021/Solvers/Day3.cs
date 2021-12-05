using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021.Solvers
{
	public sealed class Day3 : Solver
	{
		private static int[] CountOnes(string[] lines)
		{
			var length = lines[0].Length;
			var ones = new int[length];

			foreach (var s in lines)
			{
				var @int = 0;

				for (int i = length - 1; i >= 0; i--)
				{
					@int += int.Parse(s[i] + "") << i;
				}

				var index = 1;

				while (@int > 0)
				{
					if (@int % 2 == 1)
					{
						ones[^index]++;
					}

					index++;
					@int >>= 1;
				}
			}

			return ones;
		}

		private static int FromBinary(string s)
		{
			var @int = 0;

			for (int i = s.Length - 1; i >= 0; i--)
			{
				@int += int.Parse(s[^(i + 1)] + "") << i;
			}

			return @int;
		}

		protected override object Part1(string[] lines)
		{
			var length = lines[0].Length;
			var ones = new int[length];
			var total = lines.Length;

			foreach (var s in lines)
			{
				var @int = 0;

				for (int i = length - 1; i >= 0; i--)
				{
					@int += int.Parse(s[i] + "") << i;
				}

				var index = 1;

				while (@int > 0)
				{
					if (@int % 2 == 1)
					{
						ones[^index]++;
					}

					index++;
					@int >>= 1;
				}
			}

			var gamma = 0;
			var epsilon = 0;

			for (int i = length - 1; i >= 0; i--)
			{
				var @int = 1 << i;

				if (ones[i] > total / 2)
				{
					gamma += @int;
				}
				else
				{
					epsilon += @int;
				}
			}

			return gamma * epsilon;
		}

		protected override object Part2(string[] lines)
		{
			int Find(bool b)
			{
				var list = new LinkedList<string>(lines);
				var bit = 0;

				while (list.Count > 1)
				{
					var ones = 0;

					foreach (var s in list)
					{
						if (s[bit] == '1')
						{
							ones++;
						}
					}

					var f = ones - list.Count / 2f;
					var sign = Math.Abs(f) < 1e-3f ? 0 : Math.Sign(f);
					var expected = sign == 0 ? '1' : (char)('0' + Math.Max(sign, 0));
					var node = list.First;

					while (node != null)
					{
						var next = node.Next;

						if ((node.Value[bit] == expected) != b)
						{
							list.Remove(node);
						}

						node = next;
					}

					bit++;
				}

				return FromBinary(list.First.Value);
			}

			var oxygen = Find(true);
			var co2 = Find(false);

			return oxygen * co2;
		}
	}
}
