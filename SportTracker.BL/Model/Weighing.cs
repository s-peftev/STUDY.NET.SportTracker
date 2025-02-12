
namespace SportTracker.BL.Model
{
	public class Weighing
	{
		public int Id { get; }
		public double Weight { get; set; }
		public DateTime WeighingDate { get; set; }
		public required string UserLogin { get; set; }
	}
}
