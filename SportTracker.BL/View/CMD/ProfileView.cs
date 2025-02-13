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

			var userInfo = new Dictionary<string, object>
			{
				{ "currentUser", _currentUser }
			};

			switch (key)
			{
				case ConsoleKey.Q:
					_eventDispatcher.Publish("index");
					break;
				case ConsoleKey.W:
					_eventDispatcher.Publish("weighingCreate", userInfo);
					break;
				case ConsoleKey.D1:
					_eventDispatcher.Publish("weighingIndex", userInfo);
					break;
			};
		}

		private void WeighingSection(List<Weighing> weighings, int maxCount)
		{
			Console.SetCursorPosition(0, 4);
			Console.WriteLine(new string('=', Console.WindowWidth));
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("WEIGHINGS" + new string(' ', 88));
			Console.Write("[W] - to add weighing" + new string(' ', 5));
			Console.WriteLine("[1] - to open weighings list");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(new string('=', Console.WindowWidth));

			for (int i = 0, k = 0; i < maxCount && i < weighings.Count; i++, k += 19)
			{
				WeighingComponent(weighings[i], 0 + k, 8);
			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(new string('=', Console.WindowWidth));
		}

		private void WeighingComponent(Weighing weighing, int coordinateX, int coordinateY)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(coordinateX, coordinateY);
			Console.Write(new string('*', 18));
			Console.SetCursorPosition(coordinateX, coordinateY + 1);
			Console.Write($"*Date: {weighing.WeighingDate:dd-MM-yyy}*");
			Console.SetCursorPosition(coordinateX, coordinateY + 2);
			Console.Write($"*Weight: {weighing.Weight:F1} kg *");
			Console.SetCursorPosition(coordinateX, coordinateY + 3);
			Console.WriteLine(new string('*', 18));
		}
	}
}
