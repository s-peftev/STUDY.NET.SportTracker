using SportTracker.BL.Model;
using SportTracker.BL.Services.Routes;
using SportTracker.BL.Services;
using SportTracker.BL.View.CMD;
using SportTracker.BL.Services.Storage;
using static SportTracker.BL.Model.User;

namespace SportTracker.BL.Controller
{
	public class UserController : Controller
	{
		private IDataStorage _dataStorage;
		public List<User> Users { get; }
		public User? CurrentUser { get; set; }


		public UserController(IRouter router, EventDispatcher eventDispatcher, IDataStorage dataStorage)
			: base(router, eventDispatcher)
		{
			_dataStorage = dataStorage;

			Users = _dataStorage.LoadData<User>();

			base.eventDispatcher.Subscribe("auth", HandleAuth);
			base.eventDispatcher.Subscribe("signUp", HandleSignUp);
		}

		private void HandleAuth(Dictionary<string, string> parameters)
		{
			var isNewUser = (CurrentUser = Users.SingleOrDefault(u => u.Login == parameters["login"])) == null;

			var nextView = isNewUser ? "signUp" : "profile";
			var nextParams = isNewUser ? parameters : new Dictionary<string, string>
			{
				{ "login", CurrentUser!.Login },
				{ "userGender", CurrentUser.UserGender.ToString() },
				{ "birthDate", CurrentUser.Birthdate.ToString() },
				{ "weight", CurrentUser.Weight.ToString() },
				{ "height", CurrentUser.Height.ToString() }
			};

			base.router.Route(nextView, nextParams);
		}

		private void HandleSignUp(Dictionary<string, string> parameters)
		{
			CurrentUser = new User
				(
				parameters["login"],
				(Gender)int.Parse(parameters["userGender"]),
				DateTime.Parse(parameters["birthDate"]),
				double.Parse(parameters["weight"]),
				double.Parse(parameters["height"])
				);

			Users.Add(CurrentUser);

			_dataStorage.SaveData<User>(Users);

			parameters["userGender"] = CurrentUser.UserGender.ToString();

			base.router.Route("profile", parameters);
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
		}*/
	}
}
