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
			CreateBookAndGetStatistics();

			Console.ReadLine();
		}

		private static void CreateBookAndGetStatistics()
		{

			// The reference to this assembly allows me to use this class to introduce
			// speech into my program. It is loaded by the dynamic language runtime
			// when the class is requested
			//SpeechSynthesizer speech = new SpeechSynthesizer();
			//speech.Speak("Hello, welcome to this stupid gradebook program");

			GradeBook book = new GradeBook();

			book.NameChanged = new NameChangedDelegate(OnNameChanged);
			//book.NameChanged = OnNameChanged; // sugar!

			// This is legal for delegates. But, if it were an event, you couldn't do this.
			// Usually, you should prefer events to provide encapsulation. Events bascially
			// translate into a private delegate behind the scenes which only publiclly expose
			// subscribe (+=) and unsubscripe (-=) methods.
			//book.NameChanged = OnNameChanged2; This will overwrite the delegate, effectively removing all subscribers.
			//book.NameChanged("Hehehehe", "I'm invoking the delegate directly from outside the class");

			book.NameChanged += OnNameChanged2; // This creates a multicast delegate.

			book.NameChanged -= OnNameChanged2; // Removes it from the multicast delegate


			// Events:
			book.NameChangedEvent += OnNameChanged;
			// You can only subscribe and unsubscribe from events. you cannot 
			// invoke or assign to them directly but only from within the methods
			// of the class. 
			//book.NameChangedEvent("This is no longer legal", "Compile Error!!!!");
			//book.NameChangedEvent = null; // Compile error!!

			// Events using convention with the title.
			book.TitleChanged += OnTitleChanged;
			book.Title = "Title";

			// This will invoke the set method on the Name property, passing in
			// "Jeff's Grade Book" as the "value". 
			book.Name = "Jeff's Grade Book";
			book.AddGrade(81); // 81 is converted to a float
			book.AddGrade(75);
			book.AddGrade(91.5f);
			// book.AddGrade(53.4); // Compile error, cannot convert double to float.

			GradeStatistics stats = book.ComputeStatistics();
			WriteResult("Average", stats.AverageGrade); // calls the one with a float result
			WriteResult("Highest", (int)stats.HighestGrade); // calls the one with a int result (it truncates)
			WriteResult("Lowest", stats.LowestGrade);

			// You can't do this because you are in a static method. Non-static fields
			// and methods are implicitly passed 'this', which is a reference to the
			// object calling the method, which you don't have in a static method and
			// therefore cannot pass to the non-static method or field. In short, if you
			// are in a static method, you can only access other static methods/properties.
			//MyProperty = 3;



		}
		static private void OnTitleChanged(object sender, TitleChangedEventArgs args)
		{
			// If you wanted to get a reference to the sender (the GradeBook), you would
			// have to do an explicit cast here
			//GradeBook book = (GradeBook)sender;
			//book.Property = "Changing a property on the sender";
			Console.WriteLine($"Changed title from {args.OldValue} to {args.NewValue}");
		}
		static private void OnNameChanged(string oldName, string newName)
		{
			Console.WriteLine($"Changing name from {oldName} to {newName}");
		}
		static private void OnNameChanged2(string oldName, string newName)
		{
			Console.WriteLine("***");
		}
		public int MyProperty { get; set; }

		// The WriteResult method is overloaded
		private static void WriteResult(string description, float result)
		{
			// Call this overload of WriteLine(). It uses placeholders in 
			// the first string argument and then uses the following parameters
			// ToString() method to fill them in. You can also add formatting
			// characters to the placeholders. Here, The format will round
			// the float to two decimal places
			Console.WriteLine("{0}: {1:F2}", description, result);

			// You can now use 'interpolation' now as well by using a $ before the string.
			Console.WriteLine($"{description}: {result}");
		}
		private static void WriteResult(string description, int result)
		{
			Console.WriteLine(description + ": " + result);
		}
	}
}
