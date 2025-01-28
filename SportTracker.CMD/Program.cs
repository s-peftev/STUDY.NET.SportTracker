using SportTracker.BL.Controller;

Console.WriteLine("Wellcome to Sport Tracker!");

Console.WriteLine("Enter your name: ");
var name = Console.ReadLine();

Console.WriteLine("Enter your gender: ");
var genderName = Console.ReadLine();

Console.WriteLine("Enter your birthdate: ");
var birthdate = DateTime.Parse(Console.ReadLine()); // TODO add try

Console.WriteLine("Enter your weight: ");
var weight = double.Parse(Console.ReadLine());

Console.WriteLine("Enter your height: ");
var height = double.Parse(Console.ReadLine());

var userController = new UserController(name, genderName, birthdate, weight, height);
userController.Save();

