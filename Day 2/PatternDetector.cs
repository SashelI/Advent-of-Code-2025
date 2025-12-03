using System.Text.RegularExpressions;

namespace Day_2
{
	public class PatternDetector
	{
		private List<string> _allIDs = new();


		public PatternDetector()
		{
			var input = File.ReadAllText("input.txt");
			foreach (var range in input.Split(','))
			{
				var bounds = range.Split('-');
				for (long i = (long)Convert.ToDouble(bounds[0]); i <= (long)Convert.ToDouble(bounds[1]); i++)
				{
					_allIDs.Add(i.ToString());
				}
			}
		}

		public long CalculateCode()
		{
			long code = 0;
			foreach (var id in _allIDs)
			{
				if (IsIdInvalid(id))
				{
					code += (long)Convert.ToDouble(id);
				}
			}

			return code;
		}

		public long CalculateCodePartTwo()
		{
			long code = 0;

			foreach (var id in _allIDs)
			{
				if (IsIdInvalidPartTwo(id))
				{
					code += (long)Convert.ToDouble(id);
				}
			}

			return code;
		}

		private bool IsIdInvalid(string id)
		{
			string pattern = id[0].ToString();
			var regex = new Regex(pattern);

			//ID in only the same digit
			if (regex.Matches(id).Count == id.Length && id.Length%2 == 0)
			{
				return true;
			}

			int i = 0;
			foreach (char digit in id[1..])
			{
				i++;
				if (digit.Equals(pattern[0]))
				{
					if (id[i..].Equals(pattern))
					{
						return true;
					}
					else
					{
						pattern += digit;
					}
				}
				else
				{
					pattern += digit;
				}
			}

			return false;
		}

		private bool IsIdInvalidPartTwo(string id)
		{
			int length = id.Length;

			for (int patternLen = 1; patternLen <= length / 2; patternLen++)
			{
				if (length % patternLen != 0)
				{
					continue;
				}

				string pattern = id.Substring(0, patternLen);
				int repeats = length / patternLen;

				bool isMatch = true;
				for (int i = 1; i < repeats; i++)
				{
					string segment = id.Substring(i * patternLen, patternLen);
					if (segment != pattern)
					{
						isMatch = false;
						break;
					}
				}

				if (isMatch && repeats >= 2)
				{
					return true;
				}
			}

			return false;
		}
	}
}
