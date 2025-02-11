using SportTracker.BL.Model;
using SportTracker.BL.Services.Routes;
using SportTracker.BL.Services;
using SportTracker.BL.View.CMD;

namespace SportTracker.BL.Controller
{
	public class UserController : Controller
	{
		public List<User> Users { get; }
		public User? CurrentUser { get; } = null;
		public bool IsNewUser { get; } = false;

		private readonly string _userListFilePath = "users.json";


		public UserController(IRouter router, EventDispatcher eventDispatcher)
			: base(router, eventDispatcher)
		{
			//Users = LoadUserData();
		}



		/*public UserController(string login)
		{
			if (string.IsNullOrWhiteSpace(login)) 
			{
				throw new ArgumentNullException(nameof(login), "Login can not be empty");
			}

			Users = LoadUserData();
			
			CurrentUser = Users.SingleOrDefault(u => u.Login == login);

			if (CurrentUser == null) 
			{
				IsNewUser = true;
				CurrentUser = new User(login, User.Gender.Unknown, DateTime.Now, 1, 1);
			}
		}*/

		/*public bool SetUserGender(string gender)
		{ 
			string normalizedGender = gender.Trim().ToLower();

			if (normalizedGender == "male" || normalizedGender == "m")
			{
				CurrentUser!.UserGender = User.Gender.Male;
				return true;
			}
			else if (normalizedGender == "female" || normalizedGender == "f")
			{
				CurrentUser!.UserGender = User.Gender.Female;
				return true;
			}

			throw new ArgumentException("Invalid gender.");
		}

		public bool SetUserBirthDate(string? birthDate)
		{
			string? normalizedBirthDate = birthDate?.Trim();

			if (DateTime.TryParse(normalizedBirthDate, out DateTime parsedDate))
			{
				CurrentUser!.Birthdate = parsedDate;
				return true;
			}
			else
			{
				throw new ArgumentException("Invalid birth date.");
			}
		}

		public bool SetUserWeight(double weight) 
		{
			CurrentUser!.Weight = weight;

			return true;
		}

		public bool SetUserHeight(double height)
		{
			CurrentUser!.Height = height;

			return true;
		}

		public void SignUpNewUser()
		{
			if (Users.Any(user => user.Login == CurrentUser!.Login))
			{
				throw new Exception("Such user is already exist!");
			}

			Users.Add(CurrentUser!);
			SaveUserData();
		}

		/// <summary>
		/// Load list of registered users
		/// </summary>
		/// <returns>List of registered users</returns>
		public List<User> LoadUserData()
		{
			return LoadData<User>(_userListFilePath);
		}

		/// <summary>
		/// Save user data
		/// </summary>
		void SaveUserData()
		{
			SaveData<User>(_userListFilePath, Users);
		}*/
	}
}
