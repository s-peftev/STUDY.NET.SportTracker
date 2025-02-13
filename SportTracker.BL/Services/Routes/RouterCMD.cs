using SportTracker.BL.Controller;
using SportTracker.BL.Services.Storage;
using SportTracker.BL.View.CMD;

namespace SportTracker.BL.Services.Routes
{
    public class RouterCMD : IRouter
    {
        private readonly EventDispatcher _eventDispatcher;
		private readonly FileStorage _fileStorage;
        private readonly List<object> _controllers = [];

		public event Action<IView>? OnViewChanged;

        public RouterCMD(EventDispatcher eventDispatcher, FileStorage fileStorage) 
        {
			_eventDispatcher = eventDispatcher;
            _fileStorage = fileStorage;

            var homeController = new HomeController(this, _eventDispatcher);
			var userController = new UserController(this, _eventDispatcher, _fileStorage);
			var weighingController = new WeighingController(this, _eventDispatcher, _fileStorage);
			var profileController = new ProfileController(this, _eventDispatcher, userController, weighingController);

			_controllers.Add(homeController);
			_controllers.Add(userController);
			_controllers.Add(weighingController);
			_controllers.Add(profileController);
		}
        public void Route(string viewName, object? data = null)
        {
            IView view = viewName switch
            {
                "auth" => new AuthView(_eventDispatcher),
                "signUp" => new SignUpView(_eventDispatcher, data),
				"profile" => new ProfileView(_eventDispatcher, data),
				_ => new NotFoundView(_eventDispatcher)
            };

            OnViewChanged?.Invoke(view);
        }
    }
}
