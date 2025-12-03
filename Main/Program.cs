using Day_1;
using Day_2;

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

		Console.WriteLine("/////////// 02 /////////// \r\n");

		var detector = new PatternDetector();
		var code = detector.CalculateCode();

		Console.WriteLine($"CODE IS {code}");

		Console.WriteLine("/////////// 02 /////////// \r\n");

		var codePartTwo = detector.CalculateCodePartTwo();
		Console.WriteLine($"CODE PART TWO IS {codePartTwo}");

		timer = (DateTime.Now - start).TotalMilliseconds;
		Console.WriteLine($"Time : {timer} ms" + "\r\n");

		Console.Read();
	}
}