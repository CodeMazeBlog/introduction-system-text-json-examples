using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonExampleProject2
{
	public class Person
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("age")]
		public int? Age { get; set; }

		[JsonPropertyName("state of origin")]
		public string StateOfOrigin { get; set; }

		[JsonPropertyName("pets")]
		public List<Pet> Pets { get; set; }

	}
}
