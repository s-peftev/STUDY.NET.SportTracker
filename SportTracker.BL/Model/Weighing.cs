
namespace SportTracker.BL.Model
{
	public class Weighing(int id, double weight, DateTime weighingDate, string userLogin)
	{
		public int Id { get; } = id;
		public double Weight { get; set; } = weight > 0 ? weight : throw new ArgumentException("Weight must be positive.");
		public DateTime WeighingDate { get; set; } = weighingDate < DateTime.Now ? weighingDate : throw new ArgumentException("Exercise date cannot be in the future.");
		public string UserLogin { get; set; } = string.IsNullOrWhiteSpace(userLogin) ? throw new ArgumentException("Login cannot be null or empty.") : userLogin;

		public override string ToString() =>
		$"Weighing of {UserLogin}: {Weight} kg on {WeighingDate:dd-MM-yyyy}";
	}
}
