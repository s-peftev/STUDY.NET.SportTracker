using SportTracker.BL.Controller;
using SportTracker.BL.Services.Storage;
using SportTracker.BL.View.CMD;

namespace SportTracker.BL.Services.Routes
{
    public class RouterCMD : IRouter
    {
        private EventDispatcher _eventDispatcher;
		private FileStorage _fileStorage;
        private readonly List<object> _controllers = [];

		public event Action<IView>? OnViewChanged;

        public RouterCMD(EventDispatcher eventDispatcher, FileStorage fileStorage) 
        {
			_eventDispatcher = eventDispatcher;
            _fileStorage = fileStorage;

            _controllers.Add(new HomeController(this, _eventDispatcher));
		}
        public void Route(string viewName, Dictionary<string, object>? parameters = null)
        {
            IView view = viewName switch
            {
                "auth" => new AuthView(),
                _ => new NotFoundView()
            };

            OnViewChanged?.Invoke(view);
        }
    }
}
