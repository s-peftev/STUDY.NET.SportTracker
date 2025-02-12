using SportTracker.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTracker.BL.View.CMD
{
	public class ProfileView(EventDispatcher eventDispatcher, Dictionary<string, string> parameters) : View, IView
	{
		private EventDispatcher _eventDispatcher = eventDispatcher;

		public void Render()
		{
			ViewLayout.SuccessAnimation();
			Console.Clear();
			Console.WriteLine($"Hello {parameters["login"]}");
			Console.WriteLine($"Genger {parameters["userGender"]}");
			Console.WriteLine($"Birth date {parameters["birthDate"]}");
			Console.WriteLine($"Weight {parameters["weight"]} kg");
			Console.WriteLine($"Height {parameters["height"]} cm");

			Console.ReadKey();
		}
	}
}
