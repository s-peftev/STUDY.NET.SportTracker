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
		/// Login
		/// </summary>
		public string Login { get; }

		private Gender _gender;
		/// <summary>
		/// User gender.
		/// </summary>
		public Gender Gender {
			get => _gender;
			set
			{ 	
				if (value == null) throw new ArgumentNullException(nameof(Gender), "Gender cannot be null");

				if (value.Name != Gender.MALE.Name 
					&& value.Name != Gender.FEMALE.Name 
					&& value.Name != Gender.UNKNOWN.Name) throw new ArgumentException("Invalid gender value.", nameof(Gender));

				_gender = value;
			} 
		}

		private DateTime _birthDate;
		/// <summary>
		/// User birthday
		/// </summary>
		public DateTime Birthdate 
		{ 
			get => _birthDate;
			set
			{
				if (value > DateTime.Now) throw new ArgumentException("Birth date cannot be in the future.", nameof(Birthdate));
				_birthDate = value;
			}
		}

		private double _weight;
		/// <summary>
		/// User weight
		/// </summary>
		public double Weight 
		{
			get => _weight;
			set
			{
				if (value <= 0) throw new ArgumentException("Weight must be greater than 0.", nameof(Weight));
				_weight = value;
			}
		}

		private double _height;
		/// <summary>
		/// User height
		/// </summary>
		public double Height
		{
			get => _height;
			set
			{
				if (value <= 0) throw new ArgumentException("Height must be greater than 0.", nameof(Height));
				_height = value;
			}
		}


		/// <summary>
		/// Create new user
		/// </summary>
		/// <param name="login">User name.</param>
		/// <param name="gender">User gender.</param>
		/// <param name="birthDay">User birthday</param>
		/// <param name="weight">User weight</param>
		/// <param name="height">User height</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		[JsonConstructor]
		public User(string login, Gender gender, DateTime birthDate, double weight, double height) 
		{
			Login = login ?? throw new ArgumentNullException(nameof(login), "Login can not be NULL or empty");
			Gender = gender;
			Birthdate = birthDate;
			Weight = weight;
			Height = height;
		}

		public User(string login) : this(login, Gender.Male, DateTime.Now, 1, 1) { }

		public override string ToString() 
		{
			return Login;
		}
	}
}
