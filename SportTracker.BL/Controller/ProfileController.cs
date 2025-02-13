
using SportTracker.BL.Model;
using SportTracker.BL.Services.Routes;
using SportTracker.BL.Services.Storage;
using SportTracker.BL.Services;

namespace SportTracker.BL.Controller
{
	public class ProfileController : Controller
	{
		private readonly UserController _userController;
		private readonly WeighingController _weighingController;

		private List<Weighing> _weighings =
		[
			new(1, 96.5, DateTime.Parse("01-01-2025"), "stan"),
			new(2, 96.3, DateTime.Parse("02-01-2025"), "stan"),
			new(3, 62.3, DateTime.Parse("02-01-2025"), "ira"),
			new(4, 96.0, DateTime.Parse("03-01-2025"), "stan"),
			new(5, 62.0, DateTime.Parse("02-01-2025"), "ira"),
			new(6, 95.0, DateTime.Parse("04-01-2025"), "stan"),
			new(7, 96.1, DateTime.Parse("05-01-2025"), "stan"),
			new(8, 95.4, DateTime.Parse("06-01-2025"), "stan"),
			new(9, 61.1, DateTime.Parse("06-01-2025"), "ira"),
			new(10, 95.1, DateTime.Parse("07-01-2025"), "stan"),
			new(11, 94.7, DateTime.Parse("08-01-2025"), "stan"),
			new(12, 95.2, DateTime.Parse("09-01-2025"), "stan"),
			new(13, 95.0, DateTime.Parse("10-01-2025"), "stan"),
			new(14, 94.3, DateTime.Parse("11-01-2025"), "stan"),
			new(15, 94.0, DateTime.Parse("12-01-2025"), "stan")
		];

		public ProfileController(IRouter router, EventDispatcher eventDispatcher, UserController userController, WeighingController weighingController)
			: base(router, eventDispatcher)
		{
			_userController = userController;
			_weighingController = weighingController;

			base.eventDispatcher.Subscribe("profile", _ => HandleProfile());
		}

		private void HandleProfile()
		{
			var currentUser = _userController.CurrentUser ?? throw new NotImplementedException();
			var userWeighings = _weighingController.Weighings.Where(w => w.UserLogin == currentUser.Login).ToList();//_weighings.Where(w => w.UserLogin == currentUser.Login).ToList();

			var data = new Dictionary<string, object?>
			{
				{ "currentUser", currentUser },
				{ "userWeighings", userWeighings },
			};

			base.router.Route("profile", data);
		}
	}
}
