using SportTracker.BL.Services;
using SportTracker.BL.Services.Routes;

namespace SportTracker.BL.Controller
{
	public class HomeController : Controller
	{
		public HomeController(IRouter router, EventDispatcher eventDispatcher) 
			: base(router, eventDispatcher)
		{
			base.eventDispatcher.Subscribe("index", _ => HandleIndex());
		}

		void HandleIndex() 
		{
			base.router.Route("auth");
		}
	}
}
