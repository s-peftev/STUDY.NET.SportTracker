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

eventDispatcher.Publish("index");




