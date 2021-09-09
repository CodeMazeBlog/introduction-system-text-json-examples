using System.Collections.Generic;

namespace JsonExampleProject1
{
	class Person
	{
		public string Name { get; set; }

		public int? Age { get; set; }

		public string StateOfOrigin { get; set; }

		public List<Pet> Pets { get; set; }
	}
}
