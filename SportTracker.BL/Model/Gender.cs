using System;

namespace SportTracker.BL.Model
{
	/// <summary>
	/// Gender.
	/// </summary>
	[Serializable]
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
			Name = name ?? throw new ArgumentNullException("Name of gender can not be NULL or empty", nameof(name));
		}

		public override string ToString() 
		{
			return Name;
		}
	}
}
