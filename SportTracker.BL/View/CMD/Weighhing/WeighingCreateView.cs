
using SportTracker.BL.Model;
using SportTracker.BL.Services;

namespace SportTracker.BL.View.CMD.Weighhing
{
	public class WeighingCreateView : View, IView
	{
		private readonly EventDispatcher _eventDispatcher;
		private readonly User _currentUser;

		public WeighingCreateView(EventDispatcher eventDispatcher, object? data)
		{
			_eventDispatcher = eventDispatcher;

			if (data is Dictionary<string, object> userInfo)
			{
				_currentUser = (User)userInfo["currentUser"];
			}

			else
				throw new ArgumentException("Invalid data type.");
		}
		public void Render()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.SetCursorPosition(65, 7);
			Console.WriteLine($"Add new weighing for {_currentUser.Login}");
			Console.SetCursorPosition(55, 11);
			Console.Write("Enter your weight (kg): ");
			Console.SetCursorPosition(45, 14);
			Console.Write("Enter weighing date (dd-MM-yyyy): ");

			//Weight section
			double weight;
			Console.SetCursorPosition(80, 11);

			do
			{
				ResetConsoleLineFrom(80);
				var input = Console.ReadLine();

				if (double.TryParse(input, out double parsedWeight))
				{
					if (parsedWeight > 0)
					{
						weight = double.Round(parsedWeight, 1);
						ResetConsoleLineFrom(80, 12);
						ShowNotification([80, 12], "Perfect!", ConsoleColor.Green, [80, 11]);
						break;
					}
					ResetConsoleLineFrom(80, 12);
					ShowNotification([80, 12], "You better eat first, and than try again. =)", ConsoleColor.Red, [80, 11]);
				}
				else
				{
					ResetConsoleLineFrom(80, 12);
					ShowNotification([80, 12], "Invalid weight format. Try one more time =)", ConsoleColor.Red, [80, 11]);
				}
			}
			while (true);

			//Weighing date section
			DateTime weighingDate;
			Console.SetCursorPosition(80, 14);

			do
			{
				ResetConsoleLineFrom(80);
				var input = Console.ReadLine();


				if (DateTime.TryParse(input, out DateTime parsedDate))
				{
					if (parsedDate <= DateTime.Now)
					{
						weighingDate = parsedDate;
						ResetConsoleLineFrom(80, 15);
						ShowNotification([80, 15], "Here we go!", ConsoleColor.Green, [80, 14]);
						Thread.Sleep(1000);
						break;
					}
					ResetConsoleLineFrom(80, 15);
					ShowNotification([80, 15], "This app ain`t for time travellers! Try one more time =)", ConsoleColor.Red, [80, 14]);

				}
				else
				{
					ResetConsoleLineFrom(80, 15);
					ShowNotification([80, 15], "Invalid date format. Try one more time =)", ConsoleColor.Red, [80, 14]);
				}

			}
			while (true);

			var weighingInfo = new Dictionary<string, object>
			{
				{ "login", _currentUser.Login },
				{ "weight",  weight },
				{ "weighingDate",  weighingDate },
			};

			_eventDispatcher.Publish("weighingSave", weighingInfo);
		}
	}
}
