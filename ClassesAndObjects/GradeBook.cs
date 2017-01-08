using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
	class GradeBook
	{
		// Make sure to allocate memory with new!
		private List<float> _grades = new List<float>();

		public static float MaximumGrade = 100.0f;
		public static float MinimumGrade = 0.0f;
		public void AddGrade(float grade)
		{
			_grades.Add(grade);
		}

		public GradeStatistics ComputeStatistics()
		{
			GradeStatistics stats = new GradeStatistics();
			float sum = 0;

			foreach (float grade in _grades)
			{
				stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
				stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
				sum += grade;
			}
			stats.AverageGrade = sum / _grades.Count;

			return stats;
		}
	}
}
