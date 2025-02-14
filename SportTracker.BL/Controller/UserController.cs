using SportTracker.BL.Model;
using SportTracker.BL.Services.Routes;
using SportTracker.BL.Services;
using SportTracker.BL.Services.Storage;
using static SportTracker.BL.Model.User;

namespace SportTracker.BL.Controller
{
	public class UserController : Controller
	{
		private readonly IDataStorage _dataStorage;
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

		private void HandleAuth(object? data)
		{
			if (data is Dictionary<string, object> userInfo)
			{
				var login = (string)userInfo["login"];
				CurrentUser = Users.SingleOrDefault(u => u.Login == login);

				if (CurrentUser == null)
					base.router.Route("signUp", userInfo);
				else
					base.eventDispatcher.Publish("profile");
			}
			else
			{
				base.router.Route("Page 404");
			}			
		}

		private void HandleSignUp(object? data)
		{
			if (data is Dictionary<string, object> userInfo)
			{
				CurrentUser = new User
				(
					(string)userInfo["login"],
					(Gender)Convert.ToInt32(userInfo["userGender"]),
					(DateTime)(userInfo["birthDate"]),
					Convert.ToDouble(userInfo["weight"]),
					Convert.ToDouble(userInfo["height"])
				);

				Users.Add(CurrentUser);
				_dataStorage.SaveData<User>(Users);

				var firstWeighing = new Dictionary<string, object>
				{
					{ "login", CurrentUser.Login },
					{ "weight",  CurrentUser.Weight },
					{ "weighingDate",  DateTime.Now },
				};

				base.eventDispatcher.Publish("weighingSave", firstWeighing);
			}
			else
			{
				base.router.Route("Page 404");
			}
		}

		public User? GetUserByLogin(string login)
		{ 
			return Users.SingleOrDefault(u => u.Login == login);
		}

		public void UpdateUser(User user)
		{
			var oldUser = GetUserByLogin(user.Login);

			if (oldUser != null) 
			{
				Users.Remove(oldUser);
			}

			Users.Add(user);

			_dataStorage.SaveData<User>(Users);

			if(user.Login == CurrentUser!.Login)
				CurrentUser = user;
		}
	}
}
