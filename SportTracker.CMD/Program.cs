using SportTracker.BL.Controller;
using SportTracker.BL.Services;
using SportTracker.BL.Services.Routes;
using SportTracker.BL.Services.Storage;

Console.WindowWidth = 155;
Console.WindowHeight = 35;

var eventDispatcher = new EventDispatcher();
var fileStorage = new FileStorage();
var router = new RouterCMD(eventDispatcher, fileStorage);

router.OnViewChanged += view =>
{
	view.Render();
};

eventDispatcher.Publish("index", []);

while (true) { }
/*
 * Console.WriteLine("Wellcome to Sport Tracker!");

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
	Console.WriteLine($"Hi, {userController!.CurrentUser!.Login}, it looks like you`re new. Let`s create you a profile!");
	bool isValidData;

	do
	{
		isValidData = false;
		Console.WriteLine("Enter your gender (Male/Female)(M/F): ");
		var genderName = Console.ReadLine();

		if (genderName != null)
		{
			try
			{
				isValidData = userController.SetUserGender(genderName);
			}
			catch (ArgumentException ex) 
			{
				Console.WriteLine(ex.Message + "Please enter Male or Female (or m/f).");
			}
		}		
	} while (!isValidData);

	do
	{
		isValidData = false;
		Console.WriteLine("Enter your birth date: ");
		var birthDate = Console.ReadLine();

		try
		{
			isValidData = userController.SetUserBirthDate(birthDate);
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine(ex.Message);
		}
	} while (!isValidData);

	do
	{
		isValidData = false;
		Console.WriteLine("Enter your weight: ");

		try
		{
			if (double.TryParse(Console.ReadLine(), out var weight))
			{
				isValidData = userController.SetUserWeight(weight);
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid number.");
			}			
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine(ex.Message);
		}
	} while (!isValidData);

	do
	{
		isValidData = false;
		Console.WriteLine("Enter your height: ");

		try
		{
			if (double.TryParse(Console.ReadLine(), out var height))
			{
				isValidData = userController.SetUserHeight(height);
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid number.");
			}
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine(ex.Message);
		}
	} while (!isValidData);

	try
	{
		userController.SignUpNewUser();
		Console.WriteLine("Your profile has been successfully created!");
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
	
}
else 
{
	Console.WriteLine($"Hi, {userController.CurrentUser}!");
}
*/



