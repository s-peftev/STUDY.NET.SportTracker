using SportTracker.BL.Controller;

Console.WriteLine("Wellcome to Sport Tracker!");

string? login = null;
UserController? userController = null;

do 
{
	Console.WriteLine("Enter your login: ");
	login = Console.ReadLine();

	if (login != null)
	{
		try
		{
			userController = new UserController(login);
		}
		catch (ArgumentNullException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
} while (userController == null);


if (userController.IsNewUser)
{
	Console.WriteLine($"Hi, {userController.TempUser.Login}, it looks like you`re new. Let`s create you a profile!");
	bool isValid = false;

	do
	{
		Console.WriteLine("Enter your gender (Male/Female)(M/F): ");
		var genderName = Console.ReadLine();

		if (genderName != null)
		{
			try
			{
				isValid = userController.SetUserGender(genderName, userController.TempUser);
			}
			catch (ArgumentException ex) 
			{
				Console.WriteLine(ex.Message);
			}
		}		
	} while (!isValid);
	

	Console.WriteLine("Enter your birthdate: ");
	var birthdate = DateTime.Parse(Console.ReadLine());

	Console.WriteLine("Enter your weight: ");
	var weight = double.Parse(Console.ReadLine());

	Console.WriteLine("Enter your height: ");
	var height = double.Parse(Console.ReadLine());

	Console.WriteLine("Compleete!");
}
else 
{
	Console.WriteLine($"Hi, {userController.CurrentUser}!");
}

Console.ReadLine();

