
namespace SportTracker.BL.View.CMD
{
	public abstract class View
	{
		protected void ShowNotification(int[] messageCoordinates, string message, ConsoleColor color, int[] cursorCoordinates)
		{
			Console.SetCursorPosition(messageCoordinates[0], messageCoordinates[1]);
			Console.ForegroundColor = color;
			Console.WriteLine($"{message}");
			Console.ResetColor();
			Console.SetCursorPosition(cursorCoordinates[0], cursorCoordinates[1]);
		}

		protected void ResetConsoleLineFrom(int cursorPositionX, int cursorPositionY = -1)
		{
			if (cursorPositionY < 0)
				cursorPositionY = Console.CursorTop;

			Console.SetCursorPosition(cursorPositionX, cursorPositionY);
			Console.Write(new string(' ', Console.WindowWidth - cursorPositionX));
			Console.SetCursorPosition(cursorPositionX, cursorPositionY);
		}
	}
}
