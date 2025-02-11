using SportTracker.BL.Controller;
using SportTracker.BL.Model;
using SportTracker.BL.Services;

namespace SportTracker.BL.View.CMD
{
	public class SignUpView(EventDispatcher eventDispatcher, Dictionary<string, string> parameters) : View, IView
	{
		private EventDispatcher _eventDispatcher = eventDispatcher;
		private readonly string login = parameters["login"];

		public void Render()
		{
			Console.Clear();
			ViewLayout.WellcomeHeader();
			Console.SetCursorPosition(50, 9);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"Hi, {login}, it looks like you`re new. Let`s create you a profile!");

			User.Gender[] genderOptions = { User.Gender.Male, User.Gender.Female };
			int selectedIndex = 0;
			ConsoleKey key;

			Console.SetCursorPosition(60, 12);
			do
			{
				RewriteConsoleLine(60);

				Console.Write("Choose your gender: ");
				Console.ForegroundColor = selectedIndex == 0 ? ConsoleColor.Green : ConsoleColor.Gray;
				Console.Write("Male");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("/");
				Console.ForegroundColor = selectedIndex == 1 ? ConsoleColor.Green : ConsoleColor.Gray;
				Console.Write("Female");
				Console.ForegroundColor = ConsoleColor.Yellow;

				key = Console.ReadKey(true).Key;

				if (key == ConsoleKey.RightArrow)
				{
					selectedIndex = (selectedIndex + 1) % genderOptions.Length;
				}
				else if (key == ConsoleKey.LeftArrow)
				{
					selectedIndex = (selectedIndex - 1 + genderOptions.Length) % genderOptions.Length;
				}

			}
			while (key != ConsoleKey.Enter);
			

			Console.ReadLine();
		}

		private void RewriteConsoleLine(int cursorPositionX)
		{
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(cursorPositionX, Console.CursorTop);
		}
	}
}
