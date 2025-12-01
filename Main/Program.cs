using Day_1;

namespace Advent_of_Code_2025;

public class AOC25
{
	static void Main(string[] args)
	{
		DateTime start;
		double timer = 0;

		Console.WriteLine("/////////// 01 /////////// \r\n");

		start = DateTime.Now;

		var dial = new SafeDial(50);
		var result = dial.PlaySequenceAndCount(0);

		Console.WriteLine($"CODE : {result}" + "\r\n");

		Console.WriteLine("/////////// 01 - 2 ///////////");

		dial.Reset();
		var result2 = dial.PlaySequenceAndCount(0, true);

		Console.WriteLine($"CODE : {result2}" + "\r\n");

		timer = (DateTime.Now - start).TotalMilliseconds;
		Console.WriteLine($"Time : {timer} ms" + "\r\n");

		Console.Read();
	}
}