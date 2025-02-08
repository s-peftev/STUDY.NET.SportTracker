using SportTracker.BL.Controller;


namespace SportTracker.BLTests.Controller
{
	[TestClass()]
	public class UserControllerTests
	{

		[TestMethod()]
		public void UserControllerTest()
		{
			var login = Guid.NewGuid().ToString();

			var userController = new UserController(login);

			Assert.AreEqual(login, userController.CurrentUser!.Login);
		}

		[TestMethod()]
		public void SignUpNewUserTest()
		{
			var login = Guid.NewGuid().ToString();
			var gender = "Male";
			var birthDate = DateTime.Now.AddYears(-29).ToString();
			var weight = 77.5;
			var height = 173;

			var userController = new UserController(login);
			userController.SetUserGender(gender);
			userController.SetUserBirthDate(birthDate);
			userController.SetUserWeight(weight);
			userController.SetUserHeight(height);
			userController.SignUpNewUser();

			var userController2 = new UserController(login);

			Assert.AreEqual(login, userController2.CurrentUser!.Login);
			Assert.AreEqual(gender, userController2.CurrentUser!.UserGender.ToString());
			Assert.AreEqual(birthDate, userController2.CurrentUser!.Birthdate.ToString());
			Assert.AreEqual(weight, userController2.CurrentUser!.Weight);
			Assert.AreEqual(height, userController2.CurrentUser!.Height);

		}
	}
}