using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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

		// Tear-down code executed after each test method
		public void Dispose()
		{
		}
	}
}
