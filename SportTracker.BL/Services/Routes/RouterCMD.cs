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

            _controllers.Add(new HomeController(this, _eventDispatcher));
			_controllers.Add(new UserController(this, _eventDispatcher, _fileStorage));
		}
        public void Route(string viewName, object? parameters = null)
        {
            IView view = viewName switch
            {
                "auth" => new AuthView(_eventDispatcher),
                "signUp" => new SignUpView(_eventDispatcher, parameters),
				"profile" => new ProfileView(_eventDispatcher, parameters),
				_ => new NotFoundView(_eventDispatcher)
            };

            OnViewChanged?.Invoke(view);
        }
    }
}
