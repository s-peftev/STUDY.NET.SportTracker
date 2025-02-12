using SportTracker.BL.Model;

namespace SportTracker.BL.View.CMD
{
	internal class ViewLayout
	{
		internal static void WellcomeHeader()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(@"
   __        __   _                            _          _   _                                    _      _                         _   __
   \ \      / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___   ___  ___   ___    ___  | |_   | |_   ___    ____   _____| | / / ___   ___ 
    \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \ / __|| _ \ / _ \ |  _  \| __|  | __||  _  \ / _ \\ /  __/|  / / / _ \|  _  \
     \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/ \__ \|  _/| (_) ||  _  /| |_   | |_ |  _  /| (_) |\| (__ |  \ \|  __/|  _  /
      \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___| |___/|_|   \___/ |_| \_\ \__|   \__||_| \_\ \___/|_\\___\|_| \_\\___||_| \_\ 
                            ");
			Console.ResetColor();
		}

		internal static void SuccessAnimation() 
		{
			var delay = 20;

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;

			
			for (int i = 65, k = 12; k < 25; i++, k++) 
			{
				Console.SetCursorPosition(i, k);
				Console.WriteLine("***");
				Thread.Sleep(delay);
			}

			for (int i = 78, k = 24; k > 8; i++, k--)
			{
				Console.SetCursorPosition(i, k);
				Console.WriteLine("***");
				Thread.Sleep(delay);
			}

			Console.SetCursorPosition(66, 30);
			Console.WriteLine("Press any key, to continue.");
			Console.ReadKey();
		}

		internal static void UserInfoComponent(User currentUser)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"User: {currentUser.Login}" + new string(' ', 5));
			Console.Write($"Genger: {currentUser.UserGender}" + new string(' ', 5));
			Console.Write($"Birth date: {currentUser.Birthdate:dd-MM-yyyy}" + new string(' ', 5));
			Console.Write($"Weight: {currentUser.Weight} kg" + new string(' ', 5));
			Console.Write($"Height: {currentUser.Height} cm" + new string(' ', 40));

			Console.WriteLine("[Q] - to logout");

			Console.WriteLine(new string('=', Console.WindowWidth));
		}
	}
}
