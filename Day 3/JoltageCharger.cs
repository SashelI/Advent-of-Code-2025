namespace Day_3
{
	public class JoltageCharger
	{
		private List<List<char>> _allBanks = new();
		private List<List<int>> _allBanksAsInt = new();

		public JoltageCharger()
		{
			foreach (var bank in File.ReadAllLines("input_exemple.txt"))
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

			Console.WriteLine($"MAX VOLTAGE FOR {CharListToString(_allBanks[bankIndex])} is {joltage}");

			return Convert.ToInt32(joltage);
		}

		private long MaxJoltageForBankPartTwo(int bankIndex)
		{
			List<int> lastActivatedBatteriesIndexes = new();
			var consideredBatteries = _allBanksAsInt[bankIndex];

			string joltage = string.Empty;

			for (int i = 0; i < 6; i++)
			{
				if (lastActivatedBatteriesIndexes.Count == 2)
				{
					consideredBatteries.RemoveAt(lastActivatedBatteriesIndexes[0]);
					consideredBatteries.RemoveAt(lastActivatedBatteriesIndexes[1]-1);
				}

				lastActivatedBatteriesIndexes.Clear();

				var maxIndex = consideredBatteries.IndexOf(consideredBatteries[..^1].Max());
				var unitIndex = consideredBatteries.IndexOf(consideredBatteries[(maxIndex + 1)..].Max());

				lastActivatedBatteriesIndexes.Add(maxIndex);
				lastActivatedBatteriesIndexes.Add(unitIndex);

				var dozen = consideredBatteries[maxIndex];
				var unit = consideredBatteries[unitIndex];
				joltage += $"{dozen}{unit}";

				Console.WriteLine($"MAX VOLTAGE FOR 0 {IntListToString(consideredBatteries)} is {joltage}");
			}

			Console.WriteLine($"MAX VOLTAGE FOR {CharListToString(_allBanks[bankIndex])} is {joltage}");
			return (long)Convert.ToDouble(joltage);
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
