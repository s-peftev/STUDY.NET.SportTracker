
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
			var userWeighings = _weighingController.Weighings.Where(w => w.UserLogin == currentUser.Login).ToList();

			var data = new Dictionary<string, object?>
			{
				{ "currentUser", currentUser },
				{ "userWeighings", userWeighings },
			};

			base.router.Route("profile", data);
		}
	}
}
