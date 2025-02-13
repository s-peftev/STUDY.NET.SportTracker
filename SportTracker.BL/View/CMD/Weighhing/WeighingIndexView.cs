using SportTracker.BL.Model;
using SportTracker.BL.Services;
using System.Collections.Generic;

namespace SportTracker.BL.View.CMD.Weighhing
{
	public class WeighingIndexView : View, IView
	{
		private readonly EventDispatcher _eventDispatcher;
		private readonly User _currentUser;
		private readonly List<Weighing> _weighings;

		public WeighingIndexView(EventDispatcher eventDispatcher, object? data)
		{
			_eventDispatcher = eventDispatcher;

			if (data is Dictionary<string, object> weighingsData)
			{
				_currentUser = (User)weighingsData["currentUser"];
				_weighings = (List<Weighing>)weighingsData["weighingsList"];
			}

			else
				throw new ArgumentException("Invalid data type.");
		}
		public void Render()
		{
			Console.Clear();
			Console.ResetColor();

			Console.WriteLine("WeighingIndexView");
			Console.ReadKey();
		}
	}
}
