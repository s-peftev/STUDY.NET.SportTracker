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

			Console.WriteLine($"Hello {currentUser.Login}");
			Console.WriteLine($"Genger {currentUser.UserGender}");
			Console.WriteLine($"Birth date {currentUser.Birthdate}");
			Console.WriteLine($"Weight {currentUser.Weight} kg");
			Console.WriteLine($"Height {currentUser.Height} cm");

			Console.ReadKey();
		}

		private void UserInfoComponent()
		{
			
		}
	}
}
