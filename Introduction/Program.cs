using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter your name: ");
			string name = Console.ReadLine();

			Console.WriteLine("How many hours of sleep did you get last night?");
			int hoursOfSleep = int.Parse(Console.ReadLine());

			Console.WriteLine("Hello {0}, you sleept {1} hours last night.", name, hoursOfSleep);

			const int RecommendedHoursOfSleep = 8;
			if (hoursOfSleep < RecommendedHoursOfSleep)
			{
				Console.WriteLine("You should probably sleep more.");
			}
			else
			{
				Console.WriteLine("You seem to be sleeping enough.");
			}
			Console.ReadLine();
		}
	}
}
