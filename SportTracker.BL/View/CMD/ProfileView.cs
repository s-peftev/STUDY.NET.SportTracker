using SportTracker.BL.Model;
using SportTracker.BL.Services;

namespace SportTracker.BL.View.CMD
{
	public class ProfileView : View, IView
	{
		private readonly EventDispatcher _eventDispatcher;
		private readonly User currentUser;

		public ProfileView(EventDispatcher eventDispatcher, object? data)
		{
			_eventDispatcher = eventDispatcher;

			if (data is Dictionary<string, object> userInfo)
				currentUser = (User)userInfo["currentUser"];
			else
				throw new ArgumentException("Invalid data type.");
		}
		public void Render()
		{
			ViewLayout.SuccessAnimation();
			Console.Clear();
			Console.ResetColor();

			ViewLayout.UserInfoComponent(currentUser);
			WeighingComponent();

			Console.ReadKey();
		}

		private void WeighingComponent()
		{
			Console.SetCursorPosition(0, 4);
			Console.WriteLine(new string('=', Console.WindowWidth));
			Console.WriteLine("WEIGHINGS");
			Console.WriteLine(new string('=', Console.WindowWidth));
		}
	}
}
