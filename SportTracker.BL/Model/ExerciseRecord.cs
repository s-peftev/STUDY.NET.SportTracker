namespace SportTracker.BL.Model
{
	public class ExerciseRecord(Exercise exercise, int sets, int reps, DateTime date)
	{
		public Exercise Exercise { get; } = exercise ?? throw new ArgumentNullException(nameof(exercise));

		public int Sets { get; } = sets > 0 ? sets : throw new ArgumentException("Sets must be positive.");
		public int Reps { get; } = reps > 0 ? reps : throw new ArgumentException("Reps must be positive.");

		public DateTime Date { get; } = date < DateTime.Now ? date : throw new ArgumentException("Exercise date cannot be in the future.");

		public override string ToString() =>
		$"{Exercise.Name}: {Reps} reps x {Sets} sets on {Date:dd-MM-yyyy}";
	}
}
