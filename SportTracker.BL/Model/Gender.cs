using System;

namespace SportTracker.BL.Model
{
	/// <summary>
	/// Gender.
	/// </summary>
	public class Gender
	{
		/// <summary>
		/// Gender name.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Create new gender.
		/// </summary>
		/// <param name="name"> Gender name. </param>
		/// <exception cref="ArgumentNullException"></exception>
		public Gender(string name) 
		{
			if (string.IsNullOrEmpty(name))
			{ 
				throw new ArgumentNullException("Name of gender can not be NULL or empty", nameof(name));
			}

			Name = name;
		}

		public override string ToString() 
		{
			return Name;
		}
	}
}
