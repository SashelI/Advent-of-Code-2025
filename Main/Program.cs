using Day_1;
using Day_2;
using Day_3;
using Day_4;
using Day_5;
using Day_6;
using Day_7;

namespace Advent_of_Code_2025;

public class AOC25
{
	static void Main(string[] args)
	{
		DateTime start;
		double timer = 0;

		start = DateTime.Now;

		/*Console.WriteLine("/////////// 01 /////////// \r\n");

		var dial = new SafeDial(50);
		var result = dial.PlaySequenceAndCount(0);

		Console.WriteLine($"CODE : {result}" + "\r\n");

		Console.WriteLine("/////////// 01 - 2 ///////////");

		dial.Reset();
		var result2 = dial.PlaySequenceAndCount(0, true);

		Console.WriteLine($"CODE : {result2}" + "\r\n");

		timer = (DateTime.Now - start).TotalMilliseconds;
		Console.WriteLine($"Time : {timer} ms" + "\r\n");*/

		/*Console.WriteLine("/////////// 02 /////////// \r\n");

		var detector = new PatternDetector();
		var code = detector.CalculateCode();

		Console.WriteLine($"CODE IS {code}");

		Console.WriteLine("/////////// 02 /////////// \r\n");

		var codePartTwo = detector.CalculateCodePartTwo();
		Console.WriteLine($"CODE PART TWO IS {codePartTwo}");*/

		/*Console.WriteLine("/////////// 03 /////////// \r\n");

		var charger = new JoltageCharger();
		var totalJoltage = charger.TotalJoltage();

		Console.WriteLine($"TOTAL JOLTAGE IS {totalJoltage}");

		Console.WriteLine("/////////// 03 - 2 /////////// \r\n");

		var totalJoltagePartTwo = charger.TotalJoltagePartTwo();
		Console.WriteLine($"TOTAL JOLTAGE PART TWO IS {totalJoltagePartTwo}");*/

		/*Console.WriteLine("/////////// 04 /////////// \r\n");

		var forklift = new Forklift();
		//forklift.PrintMatrix();
		Console.WriteLine("-----------------------------------------");
		var count = forklift.CountPaperRolls(4);

		Console.WriteLine($"TOTAL PAPER ROLLS IS {count}");

		Console.WriteLine("/////////// 04 - 2 /////////// \r\n");

		var count2 = forklift.CountPaperRollsPartTwo();

		Console.WriteLine($"TOTAL PAPER ROLLS PART TWO IS {count2}");*/

		/*Console.WriteLine("/////////// 05 /////////// \r\n");

		var inventory = new Inventory();
		var validCount = inventory.CountFreshIngredients();

		Console.WriteLine($"TOTAL VALID ITEMS IS {validCount}");

		Console.WriteLine("/////////// 05 - 2 /////////// \r\n");

		var validIdCount = inventory.CountValidIds();
		Console.WriteLine($"TOTAL VALID IDS IS {validIdCount}");*/

		/*Console.WriteLine("/////////// 06 /////////// \r\n");
		var mathSheet = new MathSheet();
		var result = mathSheet.CalculateResult();

		Console.WriteLine($"RESULT IS {result}");

		Console.WriteLine("/////////// 06 - 2 /////////// \r\n");

		var resultPartTwo = mathSheet.CalculateResultPartTwo();

		Console.WriteLine($"RESULT PART TWO IS {resultPartTwo}");*/

		Console.WriteLine("/////////// 07 /////////// \r\n");

		var beamSimulator = new TachyonBeam();
		var result = beamSimulator.SimulateBeam();
		Console.WriteLine($"RESULT IS {result}");

		Console.WriteLine("/////////// 07 - 2 /////////// \r\n");

		var resultPartTwo = beamSimulator.SimulateBeamPartTwo();
		Console.WriteLine($"RESULT PART TWO IS {resultPartTwo}");

		timer = (DateTime.Now - start).TotalMilliseconds;
		Console.WriteLine($"Time : {timer} ms" + "\r\n");

		Console.Read();
	}
}