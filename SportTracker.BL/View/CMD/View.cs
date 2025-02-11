
namespace SportTracker.BL.View.CMD
{
	public abstract class View
	{
		protected void ShowErrorMessage(int[] messageCoordinates, string message, int[] cursorCoordinates)
		{
			Console.SetCursorPosition(messageCoordinates[0], messageCoordinates[1]);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"{message}");
			Console.ResetColor();
			Console.SetCursorPosition(cursorCoordinates[0], cursorCoordinates[1]);
		}
	}
}
