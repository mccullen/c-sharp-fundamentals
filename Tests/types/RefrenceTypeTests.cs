using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ClassesAndObjects;

namespace Tests.types
{
	public class TypeTests : IDisposable
	{
		public TypeTests()
		{

		}

		[Fact]
		public void GradeBookVariablesHoldAReference()
		{
			// Reference type: Defined as classes in a .cs file.

			// g1 is a pointer to a GradeBook. In C++ this would be similar to saying
			// GradeBook* g1 = new GradeBook();
			GradeBook g1 = new GradeBook();

			// g2 is a pointer to the same GradeBook pointed to by g1. In C++ this would
			// be: GradeBook* g2 = g1;
			GradeBook g2 = g1;

			g1.Name = "Jeff"; // Sets name property for both g1 and g2

			// Note that the "." operator derefences the pointer and then gets the value of
			// the property. In C++ it is like this: g1->Name or (*g1).Name
			Assert.Equal(g1.Name, g2.Name);

			// g2 now points to a diffrent GradeBook then g1
			g2 = new GradeBook() { Name = "Andrew" };
			Assert.NotEqual(g1.Name, g2.Name);
		}
		[Fact]
		public void IntVariablesHoldAValue()
		{
			// Integers are value types

			int x1 = 100;

			// Here, you are createing a copy of the value of x1 and storing it
			// in x2. 
			int x2 = x1;

			// Now you are chainging the value of x1, but this has no effect on x2
			// since these are value types, not referene types. x1 and x2 are not
			// pointers to the same object.
			x1 = 4;

			Assert.NotEqual(x1, x2);
		}

		[Fact]
		public void StringComparisons()
		{
			// Strings are reference types (it is a class)
			string name1 = "Jeff";
			string name2 = "jeff";

			bool result; // value types (it is a struct)

			// Do a string comparison, ignoreing case. Notice that StringComparison is a 
			// value type (it is an enum) under the System namesapce. 
			result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
			Assert.True(result);
		}
		[Fact]
		public void ReferenceTypesPassByValue()
		{
			// book1 and book 2 are GradeBook pointers to the same GradeBook
			GradeBook book1 = new GradeBook();
			GradeBook book2 = book1;

			// Here, you are passing the GradeBook pointer by value (like passing 
			// a GradeBook* by value in C++). It will set both book names to the
			// same value since they both point to the same object. The function
			// recieves a copy of the pointer (not the pointer itself) so you
			// can change the value of the thing it points to but not the pointer
			// itself.
			giveBookAName(book2);
			Assert.Equal(book1.Name, book2.Name);
		}

		private void giveBookAName(GradeBook book)
		{
			// If you uncomment this, the test will fail since you will be setting
			// the Name property on a new GradeBook. You have set the GradeBook
			// pointer to point to a new object in memory. 
			//book = new GradeBook();

			// Dereference to pointer and go to the Name property and change it.
			book.Name = "A GradeBook";
		}

		[Fact]
		public void ValueTypesPassByValue()
		{
			int x = 46;
			// Here, you pass a value type by value. A copy of the value is made
			// so you cannt change x. 
			incrementNumber(x);
			Assert.Equal(x, 46);
		}
		private void incrementNumber(int number)
		{
			number += 1;
		}

		[Fact]
		public void PassByRefAndOut()
		{
			// ref: argument must be initialized
			// out: parameter must be assigned within function

			int x;
			// Use of unassigned local variable error
			//incrementByRef(ref x);

			// Since you pass x in by reference, the value of x gets incremented.
			x = 5;
			incrementByRef(ref x);
			Assert.Equal(x, 6);

			int y = 5;
			int result;
			// Notice result does not need a value when it is passed in but it WILL have
			// a value coming out.
			incrementByOut(y, out result);
			Assert.Equal(result, 6);
		}

		private void incrementByRef(ref int number)
		{
			// Since number is a ref paramters, it must have
			// a value coming in but you are not forced to
			// assign it a new value.

			number += 1;
		}
		private void incrementByOut(int numberToIncrement, out int result)
		{
			// Since number is an output paramter, it must be assigned
			// something before function exits but there is no guarantee
			// it has an initial value coming in, though it can.

			// This will give you an "use of unassigned local variable" error.
			// You can't assume an out parameter has an input value.
			//result += 1

			result = numberToIncrement + 1;
		}

		[Fact]
		public void ValueTypesAreUsuallyImmutable()
		{
			DateTime date = new DateTime(2002, 1, 1);
			// Since DateTime is an immutable value type, you must
			// use an assignment here. AddDays() will return a new DateTime instance.
			date.AddDays(1);
			Assert.NotEqual(2, date.Day); // Note the day didn't change
			date = date.AddDays(1);
			Assert.Equal(2, date.Day); // Day changed since you assigned a new DateTime to date.

			// Strings are reference types but they are a special case and behave 
			// like value types in this regard (they are immutable)
			string name = " Jeff ";
			name.Trim();
			Assert.Equal(" Jeff ", name);
			// If you want to save the result, you must use assignment to get a newly
			// created string. Remember, strings are immutable!
			name = name.Trim();
			Assert.Equal("Jeff", name);

			// Here is another example using string's uppercase method
			string animal = "cow";
			animal.ToUpper();
			Assert.NotEqual(animal, "COW");
			animal = animal.ToUpper();
			Assert.Equal(animal, "COW");
		}

		[Fact]
		public void UsingArrays()
		{
			// This creates an array that can point to any array of floating
			// point numbers.
			float[] grades;

			// You must give an array a fixed-size initializer
			grades = new float[3];

			// You can leave it blank if you use the initialization syntax.
			// The compiler can figure out what number needs to go there.
			string[] names = new string[] { "Jeff", "Andrew" };

			// since arrays are reference types, this will work even though
			// floats are value types.
			addGrades(grades);

			Assert.Equal(89.1f, grades[1], 2);
		}

		private void addGrades(float[] grades)
		{
			//grades = new float[5]; // this will cause a failure. 
			grades[1] = 89.1f;
		}

		public void Dispose()
		{
		}
	}
}
