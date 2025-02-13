using SportTracker.BL.Model;
using SportTracker.BL.Services;

namespace SportTracker.BL.View.CMD
{
	public class ProfileView : View, IView
	{
		private readonly EventDispatcher _eventDispatcher;
		private readonly User _currentUser;
		private readonly List<Weighing> _weighings;

		public ProfileView(EventDispatcher eventDispatcher, object? data)
		{
			_eventDispatcher = eventDispatcher;

			if (data is Dictionary<string, object> userInfo) 
			{
				_currentUser = (User)userInfo["currentUser"];
				_weighings = (List<Weighing>)userInfo["userWeighings"];
			}
				
			else
				throw new ArgumentException("Invalid data type.");
		}
		public void Render()
		{
			ViewLayout.SuccessAnimation();
			Console.Clear();
			Console.ResetColor();
			ConsoleKey key;

			ViewLayout.UserInfoComponent(_currentUser);

			var sortedWeights = _weighings.OrderByDescending(w => w.WeighingDate).ToList();
			WeighingSection(sortedWeights, 8);

			var navigationKeys = new List<ConsoleKey>
			{
				ConsoleKey.Q,
				ConsoleKey.W,
				ConsoleKey.D1,
			};

			do
			{
				key = Console.ReadKey(true).Key;
			}
			while (!navigationKeys.Contains(key));

			switch (key)
			{
				case ConsoleKey.Q:
					_eventDispatcher.Publish("index");
					break;
			};
		}

		private void WeighingSection(List<Weighing> weighings, int maxCount)
		{
			Console.SetCursorPosition(0, 4);
			Console.WriteLine(new string('=', Console.WindowWidth));
			Console.WriteLine("WEIGHINGS");
			Console.WriteLine(new string('=', Console.WindowWidth));

			for (int i = 0, k = 0; i < maxCount && i < weighings.Count; i++, k += 19)
			{
				WeighingComponent(weighings[i], 0 + k, 8);
			}
			
			Console.WriteLine(new string('=', Console.WindowWidth));
		}

		private void WeighingComponent(Weighing weighing, int coordinateX, int coordinateY)
		{
			Console.SetCursorPosition(coordinateX, coordinateY);
			Console.Write(new string('*', 18));
			Console.SetCursorPosition(coordinateX, coordinateY + 1);
			Console.Write($"*Date: {weighing.WeighingDate:dd-MM-yyy}*");
			Console.SetCursorPosition(coordinateX, coordinateY + 2);
			Console.Write($"*Weight: {weighing.Weight} kg *");
			Console.SetCursorPosition(coordinateX, coordinateY + 3);
			Console.WriteLine(new string('*', 18));
		}
	}
}
