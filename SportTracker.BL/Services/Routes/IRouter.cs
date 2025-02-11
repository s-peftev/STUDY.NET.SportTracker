using SportTracker.BL.View.CMD;

namespace SportTracker.BL.Services.Routes
{
    public interface IRouter
    {
        public event Action<IView>? OnViewChanged;
        void Route(string viewName, Dictionary<string, object>? parameters = null);
    }
}
