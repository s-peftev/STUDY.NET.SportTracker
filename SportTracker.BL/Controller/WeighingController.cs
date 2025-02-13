
using SportTracker.BL.Model;
using SportTracker.BL.Services.Routes;
using SportTracker.BL.Services.Storage;
using SportTracker.BL.Services;

namespace SportTracker.BL.Controller
{
	public class WeighingController : Controller
	{
		private readonly IDataStorage _dataStorage;
		private readonly UserController _userController;
		public List<Weighing> Weighings { get; }


		public WeighingController(IRouter router, EventDispatcher eventDispatcher, IDataStorage dataStorage, UserController userController)
			: base(router, eventDispatcher)
		{
			_dataStorage = dataStorage;
			_userController = userController;

			Weighings = _dataStorage.LoadData<Weighing>();

			base.eventDispatcher.Subscribe("weighingCreate", HandleCreate);
			base.eventDispatcher.Subscribe("weighingIndex", HandleIndex);
			base.eventDispatcher.Subscribe("weighingSave", HandleSave);
		}

		private void HandleCreate(object? data)
		{
			base.router.Route("weighingCreate", data);
		}

		private void HandleIndex(object? data)
		{
			if (data is Dictionary<string, object> weighingsData)
			{
				weighingsData["weighingsList"] = Weighings;

				base.router.Route("weighingIndex", weighingsData);
			}
			else
			{
				base.router.Route("Page 404");
			}
		}

		private void HandleSave(object? data)
		{
			if (data is Dictionary<string, object> weighingData)
			{
				string userLogin = (string)weighingData["login"];
				double userWeight = (double)weighingData["weight"];
				DateTime weighingDate = (DateTime)weighingData["weighingDate"];

				if (_userController.Users.Any(u => u.Login == userLogin))
				{
					Weighing? userWeighing = Weighings.SingleOrDefault(w => w.WeighingDate == weighingDate && w.UserLogin == userLogin);
					
					if (userWeighing != null) {
						Weighings.Remove(userWeighing);
					}

					var newWeighing = new Weighing(Guid.NewGuid().GetHashCode(), userWeight, weighingDate, userLogin);
					Weighings.Add(newWeighing);

					_dataStorage.SaveData<Weighing>(Weighings);

					var lastUserWeighing = Weighings.Where(w => w.UserLogin == userLogin).OrderByDescending(w => w.WeighingDate).First();
					var oldUser = _userController.GetUserByLogin(userLogin);
					var userForUpdate = new User(oldUser!.Login, oldUser.UserGender, oldUser.Birthdate, lastUserWeighing.Weight, oldUser.Height);
					_userController.UpdateUser(userForUpdate);

					base.eventDispatcher.Publish("profile");
				}
			}
			else
			{
				base.router.Route("Page 404");
			}
		}
	}
}
