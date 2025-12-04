namespace Day_4
{
	public class Forklift
	{
		private List<List<int>> _paperMatrix = new(){};

		public Forklift()
		{
			int i = 0;

			foreach (var line in File.ReadAllLines("input.txt"))
			{
				_paperMatrix.Add(new List<int>());
				foreach (var c in line)
				{
					int isPaperRoll = Convert.ToInt32(c.Equals('@'));
					_paperMatrix[i].Add(isPaperRoll);
				}

				i++;
			}
		}

		public int CountPaperRolls(int maxNeighbours)
		{
			int paperRolls = 0;
			List<List<int>> debug = new List<List<int>>(){new()};

			for (int y = 0; y < _paperMatrix.Count; y++)
			{
				for (int x = 0; x < _paperMatrix[y].Count; x++)
				{
					if (_paperMatrix[y][x] == 1 && PaperIsAccessible(maxNeighbours, x, y))
					{
						paperRolls++;
						//debug[y].Add(1);
					}
					else
					{
						//debug[y].Add(0);
					}
				}

				//debug.Add(new List<int>());
			}

			//PrintMatrix(debug);
			return paperRolls;
		}

		public int CountPaperRollsPartTwo()
		{
			int totalRemoved = 0;

			Queue<(int x, int y)> toCheck = new();
			HashSet<(int x, int y)> inQueue = new();

			for (int y = 0; y < _paperMatrix.Count; y++)
			{
				for (int x = 0; x < _paperMatrix[y].Count; x++)
				{
					if (_paperMatrix[y][x] == 1)
					{
						toCheck.Enqueue((x, y));
						inQueue.Add((x, y));
					}
				}
			}

			while (toCheck.Count > 0)
			{
				var (x, y) = toCheck.Dequeue();
				inQueue.Remove((x, y));

				if (_paperMatrix[y][x] == 0) continue;

				if (PaperIsAccessible(4, x, y))
				{
					_paperMatrix[y][x] = 0;
					totalRemoved++;

					AddNeighboursToQueue(x, y, toCheck, inQueue);
				}
			}

			return totalRemoved;
		}

		private void AddNeighboursToQueue(int x, int y, Queue<(int, int)> queue, HashSet<(int, int)> inQueue)
		{
			int[] dx = { 0, 0, -1, 1, -1, 1, -1, 1 };
			int[] dy = { -1, 1, 0, 0, -1, -1, 1, 1 };

			for (int i = 0; i < 8; i++)
			{
				int nx = x + dx[i];
				int ny = y + dy[i];

				if (nx >= 0 && nx < _paperMatrix[0].Count &&
					ny >= 0 && ny < _paperMatrix.Count &&
					_paperMatrix[ny][nx] == 1 &&
					!inQueue.Contains((nx, ny)))
				{
					queue.Enqueue((nx, ny));
					inQueue.Add((nx, ny));
				}
			}
		}

		private bool PaperIsAccessible(int maxNeighbours, int x, int y)
		{
			int neighbours = 0;

			// Up
			if (y > 0 && _paperMatrix[y - 1][x] == 1)
				neighbours++;
			// Down
			if (y < _paperMatrix.Count - 1 && _paperMatrix[y + 1][x] == 1)
				neighbours++;
			// Left
			if (x > 0 && _paperMatrix[y][x - 1] == 1)
				neighbours++;
			// Right
			if (x < _paperMatrix[y].Count - 1 && _paperMatrix[y][x + 1] == 1)
				neighbours++;

			//UpperLeft
			if(x>0 && y>0 && _paperMatrix[y - 1][x - 1] == 1)
				neighbours++;

			//UpperRight
			if(x < _paperMatrix[y].Count - 1 && y>0 && _paperMatrix[y-1][x + 1] == 1)
				neighbours++;

			//LowerLeft
			if(x>0 && y < _paperMatrix.Count - 1 && _paperMatrix[y+1][x - 1] == 1)
				neighbours++;

			//LowerRight
			if(x < _paperMatrix[y].Count - 1 && y < _paperMatrix.Count - 1 && _paperMatrix[y + 1][x + 1] == 1)
				neighbours++;

			return neighbours < maxNeighbours;
		}

		public void PrintMatrix(List<List<int>> paperMatrix)
		{
			foreach (var line in paperMatrix)
			{
				foreach (var i in line)
				{
					Console.Write($"{i}");
				}
				Console.WriteLine();
			}
		}

		public void PrintMatrix()
		{
			foreach (var line in _paperMatrix)
			{
				foreach (var i in line)
				{
					Console.Write($"{i}");
				}
				Console.WriteLine();
			}
		}
	}
}
