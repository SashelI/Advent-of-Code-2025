namespace Day_3
{
	public class JoltageCharger
	{
		private List<List<char>> _allBanks = new();
		private List<List<int>> _allBanksAsInt = new();

		public JoltageCharger()
		{
			foreach (var bank in File.ReadAllLines("input.txt"))
			{
				var joltages = new List<char>();
				var intJoltages = new List<int>();

				foreach (var joltage in bank)
				{
					joltages.Add(joltage);
					intJoltages.Add(Convert.ToInt32(joltage.ToString()));
				}

				_allBanks.Add(joltages);
				_allBanksAsInt.Add(intJoltages);
			}
		}

		public long TotalJoltage()
		{
			long result = 0;
			for (int i = 0; i < _allBanks.Count; i++)
			{
				result += MaxJoltageForBank(i);
			}

			return result;
		}

		public long TotalJoltagePartTwo()
		{
			long result = 0;
			for (int i = 0; i < _allBanks.Count; i++)
			{
				result += MaxJoltageForBankPartTwo(i);
			}

			return result;
		}

		private int MaxJoltageForBank(int bankIndex)
		{
			var bank = _allBanksAsInt[bankIndex];

			var maxIndex = bank.IndexOf(bank[..^1].Max());
			var unitIndex = bank.IndexOf(bank[(maxIndex+1)..].Max());

			var dozen = _allBanks[bankIndex][maxIndex];
			var unit = _allBanks[bankIndex][unitIndex];
			string joltage = $"{dozen}{unit}";

			//Console.WriteLine($"MAX VOLTAGE FOR {CharListToString(_allBanks[bankIndex])} is {joltage}");

			return Convert.ToInt32(joltage);
		}

		
		private void MaxJoltageForBank(List<int> bank, ref List<(int, int)> lastPicks, ref string totalJoltage, int iteration)
		{
			if (iteration >= 12) return;

			var picks = lastPicks;
			var pick = bank.Index()
				.SkipLast(12 - iteration - 1)
				.Where(x => picks.Count == 0 || x.Index > picks[^1].Item1)
				.MaxBy(x => x.Item);

			lastPicks.Add(pick);

			string joltage = $"{pick.Item}";

			totalJoltage+=joltage;

			MaxJoltageForBank(bank,ref lastPicks, ref totalJoltage, iteration+1);
		}

		private long MaxJoltageForBankPartTwo(int bankIndex)
		{
			string totalJoltage = string.Empty;
			var picksList = new List<(int Index, int Item)>();

			MaxJoltageForBank(new List<int>(_allBanksAsInt[bankIndex]), ref picksList, ref totalJoltage, 0);

			//Console.WriteLine($"MAX VOLTAGE FOR {CharListToString(_allBanks[bankIndex])} is {totalJoltage}");
			return (long)Convert.ToDouble(totalJoltage);
		}

		private string CharListToString(List<char> list)
		{
			string result = string.Empty;
			foreach (var c in list)
			{
				result += c;
			}

			return result;
		}

		private string IntListToString(List<int> list)
		{
			string result = string.Empty;
			foreach (var c in list)
			{
				result += c.ToString();
			}

			return result;
		}
	}
}
