namespace SportTracker.BL.Model
{
	public class Activity
	{
		public string Name { get; set; }

		public Activity(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Activity name cannot be empty.", nameof(name));

			Name = name;
		}

		public override string ToString() => Name;
	}
}
