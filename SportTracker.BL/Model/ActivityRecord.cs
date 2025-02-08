namespace SportTracker.BL.Model
{
	public class ActivityRecord(Activity activity, double count, string measurementUnits, DateTime date)
	{
		public Activity Activity { get; } = activity ?? throw new ArgumentNullException(nameof(activity));

		public double Count { get; } = count > 0 ? count : throw new ArgumentException("Count must be positive.");

		public string MeasurementUnits { get; } = measurementUnits ?? throw new ArgumentNullException(nameof(activity));

		public DateTime Date { get; } = date < DateTime.Now ? date : throw new ArgumentException("Exercise date cannot be in the future.");

		public override string ToString() =>
		$"{Activity.Name}: {Count} {MeasurementUnits} on {Date:dd-MM-yyyy}";
	}
}
