using SportTracker.BL.Model;
using SportTracker.BL.Services;

namespace SportTracker.BL.View.CMD
{
	public class SignUpView : View, IView
	{
		private EventDispatcher _eventDispatcher;
		private readonly string _login;

		public SignUpView(EventDispatcher eventDispatcher, object? data)
		{
			_eventDispatcher = eventDispatcher;

			if (data is Dictionary<string, object> userInfo)
				_login = (string)userInfo["login"];
			else
				throw new ArgumentException("Invalid data type.");
		}
		public void Render()
		{
			Console.Clear();
			ViewLayout.WellcomeHeader();
			Console.SetCursorPosition(50, 9);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"Hi, {_login}, it looks like you`re new. Let`s create you a profile!");
			
			Console.SetCursorPosition(60, 12);
			Console.Write("Choose your gender: ");
			Console.SetCursorPosition(44, 15);
			Console.WriteLine("Enter your birth date (DD-MM-YYYY): ");
			Console.SetCursorPosition(56, 18);
			Console.Write("Enter your weight (kg): ");
			Console.SetCursorPosition(56, 21);
			Console.Write("Enter your height (cm): ");

			ConsoleKey key;

			//Gender section
			User.Gender[] genderOptions = { User.Gender.Male, User.Gender.Female };
			int selectedGenderIndex = 0;
			Console.SetCursorPosition(80, 12);

			do
			{
				ResetConsoleLineFrom(80);

				Console.ForegroundColor = selectedGenderIndex == 0 ? ConsoleColor.Green : ConsoleColor.Gray;
				Console.Write($"{genderOptions[0]}");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("/");
				Console.ForegroundColor = selectedGenderIndex == 1 ? ConsoleColor.Green : ConsoleColor.Gray;
				Console.Write($"{genderOptions[1]}");
				Console.ForegroundColor = ConsoleColor.Yellow;

				key = Console.ReadKey(true).Key;

				if (key == ConsoleKey.RightArrow)
				{
					selectedGenderIndex = (selectedGenderIndex + 1) % genderOptions.Length;
				}
				else if (key == ConsoleKey.LeftArrow)
				{
					selectedGenderIndex = (selectedGenderIndex - 1 + genderOptions.Length) % genderOptions.Length;
				}

			}
			while (key != ConsoleKey.Enter);
			ShowNotification([80, 13], "Nice choice! =)", ConsoleColor.Green, [80, 15]);

			//Birh date section
			DateTime birthDate;
			Console.SetCursorPosition(80, 15);

			do
			{
				ResetConsoleLineFrom(80);
				var input = Console.ReadLine();


				if (DateTime.TryParse(input, out DateTime parsedDate))
				{
					if (parsedDate <= DateTime.Now)
					{
						birthDate = parsedDate;
						ResetConsoleLineFrom(80, 16);
						ShowNotification([80, 16], "Here we go!", ConsoleColor.Green, [80, 15]);
						break;
					}
					ResetConsoleLineFrom(80, 16);
					ShowNotification([80, 16], "This app ain`t for time travellers! Try one more time =)", ConsoleColor.Red, [80, 15]);

				}
				else
				{
					ResetConsoleLineFrom(80, 16);
					ShowNotification([80, 16], "Invalid date format. Try one more time =)", ConsoleColor.Red, [80, 15]);
				}
				
			}
			while (true);

			//Weight section
			double weight;
			Console.SetCursorPosition(80, 18);

			do
			{
				ResetConsoleLineFrom(80);
				var input = Console.ReadLine();

				if (double.TryParse(input, out double parsedWeight))
				{
					if (parsedWeight > 0)
					{
						weight = parsedWeight;
						ResetConsoleLineFrom(80, 19);
						ShowNotification([80, 19], "Perfect!", ConsoleColor.Green, [80, 18]);
						break;
					}
					ResetConsoleLineFrom(80, 19);
					ShowNotification([80, 19], "You better eat first, and than try again. =)", ConsoleColor.Red, [80, 18]);
				}
				else
				{
					ResetConsoleLineFrom(80, 19);
					ShowNotification([80, 19], "Invalid weight format. Try one more time =)", ConsoleColor.Red, [80, 18]);
				}
			}
			while (true);

			//Height section
			double height;
			Console.SetCursorPosition(80, 21);

			do
			{
				ResetConsoleLineFrom(80);
				var input = Console.ReadLine();

				if (double.TryParse(input, out double parsedHeight))
				{
					if (parsedHeight > 0)
					{
						height = parsedHeight;
						ResetConsoleLineFrom(80, 22);
						ShowNotification([80, 22], "Magnificent!", ConsoleColor.Green, [80, 21]);
						Thread.Sleep(1000);
						break;
					}
					ResetConsoleLineFrom(80, 22);
					ShowNotification([80, 22], "Liar! Tell me the truth! =)", ConsoleColor.Red, [80, 21]);
				}
				else
				{
					ResetConsoleLineFrom(80, 22);
					ShowNotification([80, 22], "Invalid height format. Try one more time =)", ConsoleColor.Red, [80, 21]);
				}
			}
			while (true);

			var userInfo = new Dictionary<string, object>
			{
				{ "login", _login },
				{ "userGender",  selectedGenderIndex },
				{ "birthDate",  birthDate },
				{ "weight",  weight },
				{ "height",  height },
			};

			_eventDispatcher.Publish("signUp", userInfo);
		}
	}
}
