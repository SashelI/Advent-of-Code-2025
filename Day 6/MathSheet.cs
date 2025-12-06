namespace Day_6
{
	public class MathSheet
	{
		private List<(bool Operation, List<long> Numbers)> _sheet = new();
		private List<(bool Operation, List<long> Numbers)> _sheetPartTwo = new();

		public MathSheet()
		{
			var tmpList = new List<List<string>>();
			var tmpListPartTwo = new List<List<string>>();

			int maxLength = 0;

			foreach (var line in File.ReadAllLines("input.txt"))
			{
				var partTwoLine = new List<string>();
				var splitLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
				tmpList.Add(splitLine);

				var maxLineLength = splitLine.MaxBy(s => s.Length);
				if (maxLineLength != null && maxLineLength.Length > maxLength)
				{
					maxLength = maxLineLength.Length;
				}

				var charLine = line.ToCharArray();
				bool spaceFound = false;
				bool numberFound = false;
				var charToAdd = new List<char>();
				for(int i=0; i<charLine.Length; i++)
				{
					var c = charLine[i];

					if (i == charLine.Length - 1)
					{
						charToAdd.Add(c);
						partTwoLine.Add(new string(charToAdd.ToArray()));
						charToAdd.Clear();
						continue;
					}

					if (spaceFound || (c.Equals(' ') && !numberFound))
					{
						spaceFound = false;
						charToAdd.Add(c);
						if (c != ' ') numberFound = true;
						continue;
					}
					if (numberFound && !spaceFound && c.Equals(' '))
					{
						spaceFound = true;
						numberFound = false;
						partTwoLine.Add(new string(charToAdd.ToArray()));
						charToAdd.Clear();
						continue;
					}

					numberFound = true;
					charToAdd.Add(c);
				}

				tmpListPartTwo.Add(partTwoLine);
			}
			tmpListPartTwo.RemoveAt(tmpListPartTwo.Count-1);

			for (int k = 0; k < tmpListPartTwo.Count; k++)
			{
				tmpListPartTwo[k] = tmpListPartTwo[k].Select(s =>
				{
					if (s.Length > maxLength)
					{
						while (s.Length > maxLength)
						{
							s = s.Replace(" ", "");
						}

						return s;
					}

					if (s.Length < maxLength)
					{
						return CorrectPadding(s, maxLength);
					}

					return s;

				}).ToList();
			}

			for (int i=0; i < tmpList[0].Count; i++)
			{
				bool mOperator = tmpList[^1][i].Equals("*");
				_sheet.Add((mOperator, tmpList[..^1].Select(l=>long.Parse(l[i])).ToList()));

				var partTwoList = new List<string>();
				for (int o = maxLength-1; o >= 0; o--)
				{
					List<char> newNumber = new();
					for (int j = 0; j < tmpListPartTwo.Count; j++)
					{
						char digit = ' ';
						if (tmpListPartTwo[j][i].Length <= o)
						{
							digit = CorrectPadding(tmpListPartTwo[j][i], maxLength)[o];
						}
						else
						{
							digit = tmpListPartTwo[j][i][o];
						}

						if (!string.IsNullOrWhiteSpace(digit.ToString()))
						{
							newNumber.Add(digit);
						}
					}

					partTwoList.Add(new string(newNumber.ToArray()));
				}

				_sheetPartTwo.Add((mOperator, partTwoList.Select(s=>!string.IsNullOrWhiteSpace(s) ? long.Parse(s) : 0).ToList()));
			}
		}

		public long CalculateResult()
		{
			long result = 0;
			foreach(var (operation, numbers) in _sheet)
			{
				long tempResult = operation ? 1 : 0;
				foreach(var number in numbers)
				{
					if (operation)
						tempResult *= number;
					else
						tempResult += number;
				}
				result += tempResult;
			}
			return result;
		}

		public long CalculateResultPartTwo()
		{
			long result = 0;
			foreach (var (operation, numbers) in _sheetPartTwo)
			{
				long tempResult = operation ? 1 : 0;
				foreach (var number in numbers)
				{
					if (operation)
						tempResult *= number;
					else
						tempResult += number;
				}
				result += tempResult;
			}
			return result;
		}

		private string CorrectPadding(string s, int maxLength)
		{
			string result = s;
			if (s.StartsWith(' '))
			{
				result = s.PadLeft(maxLength);
			}
			else
			{
				result = s.PadRight(maxLength);
			}

			return result;
		}
	}
}
