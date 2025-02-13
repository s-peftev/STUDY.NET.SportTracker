﻿
using SportTracker.BL.Services;

namespace SportTracker.BL.View.CMD
{
	public class AuthView(EventDispatcher eventDispatcher) : View, IView
	{
		private EventDispatcher _eventDispatcher = eventDispatcher;
		public void Render()
		{
			Console.Clear();
			ViewLayout.WellcomeHeader();
			Console.SetCursorPosition(60, 17);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("ENTER YOUR LOGIN:" + new string('_', 22));
			Console.ResetColor();
			Console.SetCursorPosition(78, 16);
			string? login;

			do
			{
				login = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(login))
				{
					ShowNotification([60, 18], "Login cannot be empty, please enter your login.", ConsoleColor.Red, [78, 16]);
				}
			}
			while (string.IsNullOrWhiteSpace(login));


			var userInfo = new Dictionary<string, object>
			{
				{ "login", login }
			};

			_eventDispatcher.Publish("auth", userInfo);
		}
	}
}
