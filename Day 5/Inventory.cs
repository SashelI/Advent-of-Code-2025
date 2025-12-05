namespace Day_5
{
	public class Inventory
	{
		private List<(long Lower, long Upper)> _ranges = new();
		private List<long> _items = new();

		public Inventory(bool partTwo=false)
		{
			bool isItems = false;
			foreach (var line in File.ReadAllLines("input.txt"))
			{
				if (string.IsNullOrWhiteSpace(line))
				{
					isItems = true;

					if (partTwo) return;
					continue;
				}

				if (isItems)
				{
					_items.Add(long.Parse(line));
				}
				else
				{
					var bounds = line.Split('-');
					_ranges.Add((long.Parse(bounds[0]), long.Parse(bounds[1])));
				}
			}

			//debug
			//PrintInventory();
		}

		public int CountFreshIngredients()
		{
			return _items.Count(IsFresh);
		}

		private bool IsFresh(long item)
		{
			return _ranges.Any(range => item <= range.Upper && item >= range.Lower);
		}

		//PartTwo
		public long CountValidIds()
		{
			return _ranges.OrderBy(r => r.Lower)
				.Aggregate(new List<(long Lower, long Upper)>(), (agg, range) =>
				{
					if (agg.Count is 0)
					{
						agg.Add(range);
					}
					else
					{
						var (lower, upper) = agg[^1];

						if (range.Lower <= upper)
						{
							agg[^1] = (lower, Math.Max(upper, range.Upper));
							//debug
							//Console.WriteLine($"DEBUG - {agg[^1].Lower},{agg[^1].Upper} from {range.Lower},{range.Upper}");
						}
						else
						{
							agg.Add(range);
							//debug
							//Console.WriteLine($"DEBUG - {range.Lower},{range.Upper}");
						}
					}

					return agg;
				})
				.Sum(r => r.Upper - r.Lower + 1);
		}

		private void PrintInventory()
		{
			foreach (var range in _ranges)
			{
				Console.WriteLine($"Range: {range.Lower} - {range.Upper}");
			}
			foreach (var item in _items)
			{
				Console.WriteLine($"Item: {item}");
			}
		}
	}
}
