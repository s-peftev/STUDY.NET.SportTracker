
using SportTracker.BL.Services;

namespace SportTracker.BL.View.CMD
{
	public class NotFoundView(EventDispatcher eventDispatcher) : IView
	{
		private EventDispatcher _eventDispatcher = eventDispatcher;
		public void Render()
		{
			Console.Clear();
			ViewLayout.WellcomeHeader();
			Console.SetCursorPosition(70, 17);
			Console.WriteLine("PAGE NOT FOUND");
			
			Console.ReadLine();

			_eventDispatcher.Publish("index", []);
		}
	}
}
