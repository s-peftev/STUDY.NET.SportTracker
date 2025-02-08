namespace SportTracker.BL.Model
{
	public class Exercise
	{
		public string Name { get; set; }

		public Exercise(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Exercise name cannot be empty.", nameof(name));

			Name = name;
		}

		public override string ToString() => Name;

	}
}
