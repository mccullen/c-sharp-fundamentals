using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
	class Program
	{
		static void Main(string[] args)
		{
			GradeBook book = new GradeBook();
			book.AddGrade(81); // 81 is converted to a float
			// book.AddGrade(53.4); // Compile error, cannot convert double to float.
		}
	}
}
