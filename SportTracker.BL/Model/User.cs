using System;
using System.Text.Json.Serialization;

namespace SportTracker.BL.Model
{
	/// <summary>
	/// User.
	/// </summary>
	[Serializable]
	public class User
	{
		/// <summary>
		/// User name.
		/// </summary>
		public string Name { get; }
		/// <summary>
		/// User gender.
		/// </summary>
		public Gender Gender { get; }
		/// <summary>
		/// User birthday
		/// </summary>
		public DateTime Birthday { get; }

		/// <summary>
		/// User weight
		/// </summary>
		public double Weight { get; set; }
		/// <summary>
		/// User height
		/// </summary>
		public double Height { get; set; }

		/// <summary>
		/// Create new user
		/// </summary>
		/// <param name="name">User name.</param>
		/// <param name="gender">User gender.</param>
		/// <param name="birthDay">User birthday</param>
		/// <param name="weight">User weight</param>
		/// <param name="height">User height</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public User(string name, Gender gender, DateTime birthDay, double weight, double height) 
		{
			#region check-up region
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("Name of user can not be NULL or empty", nameof(name));
			}

			if (gender == null) 
			{
				throw new ArgumentNullException("Gender be NULL", nameof(gender));
			}

			if (birthDay < DateTime.Parse("01.01.1900") || birthDay >= DateTime.Now) 
			{
				throw new ArgumentException("Impossible date of birth", nameof(birthDay));
			}

			if (weight <= 0) 
			{
				throw new ArgumentException("Weight can not be less or equal 0", nameof(weight));
			}

			if (height <= 0) 
			{
				throw new ArgumentException("Height can not be less or equal 0", nameof(height));
			}
			#endregion

			Name = name;
			Gender = gender;
			Birthday = birthDay;
			Weight = weight;
			Height = height;
		}

		public override string ToString() 
		{
			return Name;
		}
	}
}
