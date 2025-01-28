using SportTracker.BL.Model;
using System;
using System.Text.Json;

namespace SportTracker.BL.Controller
{
	public class UserController
	{
		public User? User { get; }

		public UserController()
		{
			using var fs = new FileStream("users.json", FileMode.OpenOrCreate);

			User = JsonSerializer.Deserialize<User>(fs) as User;
		}

		public UserController(string username, string genderName, DateTime birthDay, double weight, double height)
		{
			// TODO: check-up

			var gender = new Gender(genderName);
			var	user = new User(username, gender, birthDay, weight, height);

			User = user;
		}

		/// <summary>
		/// Save user data
		/// </summary>
		public void Save()
		{
			using var fs = new FileStream("users.json", FileMode.OpenOrCreate);
			JsonSerializer.Serialize(fs, User);
		}
	}
}
