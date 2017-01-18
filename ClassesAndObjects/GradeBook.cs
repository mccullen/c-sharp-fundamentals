﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
	// Marking class as public makes it available to referencing assemblies
	// marking it as internal (the default) would mean it is not.
	public class GradeBook
	{
		public GradeBook()
		{
			// Note: Normally it is safer to set properties rather than
			// the underlying backing field. 
			_name = "Empty";
		}
		// The delegate allows for methods to become subscribed to your class.
		public NameChangedDelegate NameChanged;

		// Since there is no body for the getter and setter, this is auto-implemented.
		// The getter simply returns the value and the setter simply sets it without
		// any custom logic. The C# compiler will automatically generate a private
		// backing field here. From the user's point of view, this usually isn't 
		// any different, but sometimes properties and fields are treated differently
		// like in serialization. Most do not consider fields when serializing. 
		//public string Name { get; set; }
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					// Name has changed so publish by invoking the delegate. This
					// will notify all the subscribers.
					_name = value;
					NameChanged(_name, value);
				}
			}
		}
		private string _name;


		// Example using non-auto-implemented property. As soon as you implement one, the
		// getter or the setter, you must implement the other also. 
		public string Property
		{
			// Must return a string here.
			get
			{
				return _property;
			}
			set
			{
				// Only set value if it is not null or empty. This is the power of ENCAPSULATION:
				// to protect the internal state of your objects!
				if (string.IsNullOrEmpty(value))
				{
					_property = value;
				}

			}
		}
		private string _property; // private backing field for Property

										   // Make sure to allocate memory with new!
		private List<float> _grades = new List<float>();

		public static float MaximumGrade = 100.0f;
		public static float MinimumGrade = 0.0f;
		public void AddGrade(float grade)
		{
			_grades.Add(grade);
		}

		// You could mark this as an internal method so that only books instantiated
		// in this assembly will be able to use it. 
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
