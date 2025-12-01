namespace Day_1
{
	public class SafeDial
	{
		public int Index { get; private set; } = 0;
		public int StartIndex { get; private set; } = 0;

		private List<int> _items = new();
		private List<Tuple<int, int>> _sequence = new(); // Key: 0=left, 1=right, Value: clicks

		public SafeDial(int startIndex)
		{
			Index = startIndex;
			StartIndex = startIndex;

			foreach (var line in File.ReadAllLines("input.txt"))
			{
				_sequence.Add(new(
					Convert.ToInt32(line.StartsWith("R", StringComparison.InvariantCultureIgnoreCase)), 
					Convert.ToInt32(line.Substring(1))
					));
			}

			for (int i = 0; i < 100; i++)
			{
				_items.Add(i);
			}
		}

		public void PlaySequence()
		{
			foreach (var rotation in _sequence)
			{
				if (rotation.Item1 == 1)
				{
					RotateRight(rotation.Item2);
				}
				else
				{
					RotateLeft(rotation.Item2);
				}
			}
		}

		public int PlaySequenceAndCount(int numberToCount, bool countEveryOccurence=false)
		{
			int nbNumber = 0;

			foreach (var rotation in _sequence)
			{
				var count = 0;

				if (rotation.Item1 == 1)
				{
					count = RotateRight(rotation.Item2, countEveryOccurence ? numberToCount : -1);
				}
				else
				{
					count = RotateLeft(rotation.Item2, countEveryOccurence ? numberToCount : -1);
				}

				if (!countEveryOccurence)
				{
					nbNumber += Convert.ToInt32(GetCurrentNumber() == numberToCount);
				}
				else
				{
					nbNumber += count;
				}
			}

			return nbNumber;
		}

		public void Reset()
		{
			Index = StartIndex;
		}

		private void Next()
		{
			Index = (Index + 1) % _items.Count;
		}

		private void Previous()
		{
			Index--;
			if (Index < 0)
			{
				Index = _items.Count - 1;
			}
		}

		private int RotateLeft(int clicks, int nbToCount=-1)
		{
			int count = 0;
			for (int i = 0; i < clicks; i++)
			{
				Previous();
				if (nbToCount >= 0)
				{
					count += Convert.ToInt32(GetCurrentNumber() == nbToCount);
				}
			}
			return count;
		}

		private int RotateRight(int clicks, int nbToCount = -1)
		{
			int count = 0;
			for (int i = 0; i < clicks; i++)
			{
				Next();
				if (nbToCount >= 0)
				{
					count += Convert.ToInt32(GetCurrentNumber() == nbToCount);
				}
			}
			return count;
		}

		public int GetCurrentNumber()
		{
			return _items[Index];
		}
	}
}
