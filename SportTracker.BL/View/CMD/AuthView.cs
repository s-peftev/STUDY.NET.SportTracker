﻿
namespace SportTracker.BL.View.CMD
{
	public class AuthView : IView
	{
		public void Render()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(@"
   __        __   _                            _          _   _                                    _      _                         _   __
   \ \      / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___   ___  ___   ___    ___  | |_   | |_   ___    ____   _____| | / / ___   ___ 
    \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \ / __|| _ \ / _ \ |  _  \| __|  | __||  _  \ / _ \\ /  __/|  / / / _ \|  _  \
     \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/ \__ \|  _/| (_) ||  _  /| |_   | |_ |  _  /| (_) |\| (__ |  \ \|  __/|  _  /
      \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___| |___/|_|   \___/ |_| \_\ \__|   \__||_| \_\ \___/|_\\___\|_| \_\\___||_| \_\ 
                            ");
			Console.ResetColor();
			Console.SetCursorPosition(60, 17);
			Console.WriteLine("ENTER YOUR LOGIN:" + new string('_', 22));
			Console.SetCursorPosition(78, 16);
			Console.ReadLine();
		}
	}
}
