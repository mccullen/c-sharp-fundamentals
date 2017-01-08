using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ClassesAndObjects;

namespace Tests
{
	// NOTE: Class MUST be public 
	public class GradeBookTests : IDisposable // allow teardown via Dispose()
	{
		// Set-up code executed before each test method...
		public GradeBookTests()
		{
		}

		[Fact]
		public void PassingTest()
		{
			Assert.Equal(true, true);
		}

		[Fact]
		public void ComputesHighestGrade()
		{
			GradeBook book = new GradeBook();
			book.AddGrade(10);
			book.AddGrade(90);
			GradeStatistics stats = book.ComputeStatistics();
			Assert.Equal(90, stats.HighestGrade);
		}
		[Fact]
		public void ComputesLowestGrade()
		{
			GradeBook book = new GradeBook();
			book.AddGrade(10);
			book.AddGrade(90);
			GradeStatistics stats = book.ComputeStatistics();
			Assert.Equal(10, stats.LowestGrade);
		}
		[Fact]
		public void ComputesAverageGrade()
		{
			GradeBook book = new GradeBook();
			book.AddGrade(91);
			book.AddGrade(89.5f);
			book.AddGrade(75);
			GradeStatistics stats = book.ComputeStatistics();
			Assert.Equal(85.16, stats.AverageGrade, 1); // Use last "precision" parameter to compare floats/doubles
		}
		// Tear-down code executed after each test method
		public void Dispose()
		{
		}
	}
}
