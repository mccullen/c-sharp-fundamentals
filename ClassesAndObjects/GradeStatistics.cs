using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
	public class GradeStatistics
	{
		public GradeStatistics()
		{
			HighestGrade = float.MinValue; // Static member to set lowest possible float value
			LowestGrade = float.MaxValue; // Static member to set the highest possible value for a float
		}
		public float AverageGrade { get; set; }
		public float HighestGrade { get; set; }
		public float LowestGrade { get; set; }
	}
}
