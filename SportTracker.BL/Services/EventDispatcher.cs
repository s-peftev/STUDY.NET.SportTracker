
namespace SportTracker.BL.Services
{
	public class EventDispatcher
	{
		private readonly Dictionary<string, List<Action<object?>>> _eventHandlers = [];

		public void Subscribe(string eventKey, Action<object?> handler) 
		{
			if (!_eventHandlers.TryGetValue(eventKey, out var value)) 
			{
				value = [];
				_eventHandlers[eventKey] = value;
			}

			value.Add(handler);
		}

		public void Publish(string eventKey, object? parameters = null)
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
