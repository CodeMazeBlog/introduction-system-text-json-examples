using System.Text.Json.Serialization;

namespace JsonExampleProject2
{
	public class Pet
	{
		public string Type { get; set; }

		public string Name { get; set; }

		[JsonIgnore]
		public double Age { get; set; }
	}
}
