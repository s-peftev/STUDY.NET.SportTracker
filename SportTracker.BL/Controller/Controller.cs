using SportTracker.BL.Services;
using SportTracker.BL.Services.Routes;

namespace SportTracker.BL.Controller
{
    public abstract class Controller(IRouter router, EventDispatcher eventDispatcher)
	{
		protected readonly IRouter router = router;
		protected readonly EventDispatcher eventDispatcher = eventDispatcher;
	}
}
