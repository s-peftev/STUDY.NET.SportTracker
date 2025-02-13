
using SportTracker.BL.Model;
using SportTracker.BL.Services.Routes;
using SportTracker.BL.Services.Storage;
using SportTracker.BL.Services;

namespace SportTracker.BL.Controller
{
	public class WeighingController : Controller
	{
		private readonly IDataStorage _dataStorage;
		public List<Weighing> Weighings { get; }


		public WeighingController(IRouter router, EventDispatcher eventDispatcher, IDataStorage dataStorage)
			: base(router, eventDispatcher)
		{
			_dataStorage = dataStorage;

			Weighings = _dataStorage.LoadData<Weighing>();
		}

		
	}
}
