
namespace SportTracker.BL.Services
{
	public class EventDispatcher
	{
		private readonly Dictionary<string, List<Action<Dictionary<string, string>>>> _eventHandlers = [];

		public void Subscribe(string eventKey, Action<Dictionary<string, string>> handler) 
		{
			if (!_eventHandlers.TryGetValue(eventKey, out var value)) 
			{
				value = [];
				_eventHandlers[eventKey] = value;
			}

			value.Add(handler);
		}

		public void Publish(string eventKey, Dictionary<string, string> parameters)
		{
			if (_eventHandlers.TryGetValue(eventKey, out var handlers)) 
			{
				foreach (var handler in handlers) 
				{
					handler(parameters);
				}
			}
		}
	}
}
