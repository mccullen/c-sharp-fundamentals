using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;


namespace ClassesAndObjects
{
	class Program
	{
		static void Main(string[] args)
		{
			//CreateBookAndGetStatistics();
			Types();

			Console.ReadLine();
		}
		private static void Types()
		{



		}

		private static void CreateBookAndGetStatistics()
		{

			// The reference to this assembly allows me to use this class to introduce
			// speech into my program. It is loaded by the dynamic language runtime
			// when the class is requested
			SpeechSynthesizer speech = new SpeechSynthesizer();
			speech.Speak("Hello, welcome to this stupid gradebook program");

			GradeBook book = new GradeBook();
			book.AddGrade(81); // 81 is converted to a float
			book.AddGrade(75);
			book.AddGrade(91.5f);
			// book.AddGrade(53.4); // Compile error, cannot convert double to float.

			GradeStatistics stats = book.ComputeStatistics();
			Console.WriteLine(stats.AverageGrade);
			Console.WriteLine(stats.LowestGrade);
			Console.WriteLine(stats.HighestGrade);

		}
	}
}
