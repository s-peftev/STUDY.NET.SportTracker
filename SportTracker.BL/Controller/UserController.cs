using SportTracker.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace SportTracker.BL.Controller
{
	public class UserController
	{
		public List<User> Users { get; }
		public User? CurrentUser { get; } = null;
		public User? TempUser { get; } = null;
		public bool IsNewUser { get; } = false;
		

		private static readonly JsonSerializerOptions s_readOptions = new()
		{
			WriteIndented = true
		};

		public UserController(string login)
		{
			if (string.IsNullOrWhiteSpace(login)) 
			{
				throw new ArgumentNullException(nameof(login), "Login can not be empty");
			}

			Users = LoadUsersData();
			
			CurrentUser = Users.SingleOrDefault(u => u.Login == login);

			if (CurrentUser == null) 
			{
				//CurrentUser = new User(login);
				//Users.Add(CurrentUser);
				IsNewUser = true;
				TempUser = new User(login, Gender.UNKNOWN, DateTime.Now, 1, 1);
				//SaveUsersData();
			}
		}

		public bool SetUserGender(string gender, User user)
		{ 
			string normalizedGender = gender.Trim().ToLower();

			if (normalizedGender == "male" || normalizedGender == "m")
			{
				user.Gender = Gender.MALE;
				return true;
			}
			else if (normalizedGender == "female" || normalizedGender == "f")
			{
				user.Gender = Gender.FEMALE;
				return true;
			}

			throw new ArgumentException("Invalid gender. Please enter Male or Female (or m/f).");
		}

		public void SetNewUserData(string gender, DateTime birthDate, double weight = 1, double height = 1) 
		{
			//TODO: add validation

			CurrentUser.Gender = Gender.MALE;
			CurrentUser.Birthdate = birthDate;
			CurrentUser.Weight = weight;
			CurrentUser.Height = height;
			SaveUsersData();

		}

		/// <summary>
		/// Load list of registered users
		/// </summary>
		/// <returns>List of registered users</returns>
		public static List<User> LoadUsersData()
		{
			using var fs = new FileStream("users.json", FileMode.OpenOrCreate);

			if (JsonSerializer.Deserialize<List<User>>(fs) is List<User> users)
			{
				return users;
			}
			else
			{
				return [];
			}
		}

		/// <summary>
		/// Save user data
		/// </summary>
		void SaveUsersData()
		{
			using var writeFs = new FileStream("users.json", FileMode.Create);
			JsonSerializer.Serialize(writeFs, Users, s_readOptions);
		}
	}
}
