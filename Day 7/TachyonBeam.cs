using System.Numerics;

namespace Day_7
{
	public class TachyonBeam
	{
		public record Beam(int X, int Y);

		private List<List<char>> _grid = new();
		private HashSet<(int x, int y)> _visited = new();
		private int _splitCount;

		private Vector2 _bounds = new();

		public TachyonBeam()
		{
			foreach (var line in File.ReadAllLines("input.txt"))
			{
				_grid.Add(line.ToCharArray().ToList());
			}

			_bounds = new(_grid[0].Count, _grid.Count);
		}

		public int SimulateBeam()
		{
			_visited = new HashSet<(int, int)>();
			_splitCount = 0;

			var start = FindStart();

			Queue<Beam> beams = new Queue<Beam>();
			beams.Enqueue(start with { Y = start.Y + 1 });

			while (beams.Count > 0)
			{
				var beam = beams.Dequeue();
				PropagateBeam(beam, beams);
			}

			return _splitCount;
		}

		private void PropagateBeam(Beam beam, Queue<Beam> queue)
		{
			if (!_visited.Add((beam.X, beam.Y)))
				return;

			if (IsOutOfBounds(beam))
				return;

			char cell = _grid[beam.Y][beam.X];

			if (cell == '^') //Splitter
			{
				_splitCount++;
				queue.Enqueue(beam with { X = beam.X - 1 });
				queue.Enqueue(beam with { X = beam.X + 1 });
			}
			else //vide
			{
				queue.Enqueue(beam with { Y = beam.Y + 1 });
			}
		}

		public long SimulateBeamPartTwo()
		{
			var beams = new Dictionary<int, long>() { [FindStart().X] = 1 };

			foreach (var line in _grid)
			{
				for (int i = 0; i < line.Count; i++)
				{
					if (line[i] is '^' && beams.Remove(i, out var count))
					{
						beams[i - 1] = beams.GetValueOrDefault(i - 1) + count;
						beams[i + 1] = beams.GetValueOrDefault(i + 1) + count;
					}
				}
			}

			return beams.Values.Sum();
		}

		private Beam FindStart()
		{
			for (int y = 0; y < _grid.Count; y++)
			{
				for (int x = 0; x < _bounds.X; x++)
				{
					if (_grid[y][x] == 'S')
						return new(x, y);
				}
			}
			throw new Exception("Start point 'S' not found in the grid.");
		}

		private bool IsOutOfBounds(Beam beam)
		{
			return beam.X > _bounds.X - 1 || beam.X < 0 || beam.Y > _bounds.Y - 1;
		}
	}
}
