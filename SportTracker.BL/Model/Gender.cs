
using System.Text.Json.Serialization;

namespace SportTracker.BL.Model
{
	public sealed class Gender
	{
		public static readonly Gender MALE = new("Male");
		public static readonly Gender FEMALE = new("Female");
		public static readonly Gender UNKNOWN = new("Unknown");

		public string Name { get; }

		[JsonConstructor]
		private Gender(string name)
		{
			Name = name;
		}

		public override string ToString() => Name;
	}
}
