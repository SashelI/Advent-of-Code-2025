using System.Numerics;

namespace Day_8
{
	public class Playground
	{
		private List<string> _input = File.ReadAllLines("input.txt").ToList();


		public long Part1() => Solve(1000);

		public long Part2() => Solve(0);

		private long Solve(int count)
		{
			//kruskal
			var junctions = Parse();
			var circuits = junctions.Select(j => new HashSet<Vector3> { j }).ToList();

			foreach (var (a, b) in Pairs(junctions).OrderBy(Distance))
			{
				var sa = circuits.First(c => c.Contains(a));
				var sb = circuits.First(c => c.Contains(b));

				if (sa != sb)
				{
					sa.UnionWith(sb);
					circuits.Remove(sb);
				}

				count--;
				if (count == 0) //This is always false in part two
				{
					return circuits
						.OrderByDescending(c => c.Count)
						.Take(3)
						.Aggregate(1, (agg, c) => agg * c.Count);
				}

				if (circuits.Any(c=>c.Count == junctions.Length)) //until we have one big circuit
				{
					return (long)a.X * (long)b.X;
				}
			}

			return -1;
		}

		private IEnumerable<(Vector3, Vector3)> Pairs(Vector3[] junctionCoordinates)
		{
			for (var i = 0; i < junctionCoordinates.Length; i++)
			{
				for (var j = i + 1; j < junctionCoordinates.Length; j++)
				{
					yield return (junctionCoordinates[i], junctionCoordinates[j]);
				}
			}
		}

		private long Distance((Vector3 A, Vector3 B) junctions)
		{
			long x = (long)(junctions.A.X - junctions.B.X);
			long y = (long)(junctions.A.Y - junctions.B.Y);
			long z = (long)(junctions.A.Z - junctions.B.Z);

			return x * x + y * y + z * z;
		}

		private Vector3[] Parse() => _input.Select(line =>
			{
				var intSplit = new List<int>();
				var split = line.Split(',');

				foreach (var s in split)
				{
					intSplit.Add(int.Parse(s));
				}

				return new Vector3(intSplit[0], intSplit[1], intSplit[2]);
			})
			.ToArray();
	}
}
