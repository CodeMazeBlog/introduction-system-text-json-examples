using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonExampleProject1
{ 
	class Program
	{
		private static async Task Main()
		{
			SerializeExample();
			await SerializeToFile();
			DeserizalizeExample();
			DeserializeWithJsonDocument();
			SerializeWithOptions();
			DeserizalizeWithOptions();
		}

		private static void SerializeExample()
		{
			var pets = new List<Pet>
			{
				new Pet { Type = "Cat", Name = "MooMoo", Age = 3.4 },
				new Pet { Type = "Squirrel", Name = "Sandy", Age = 7}
			};

			var person = new Person
			{
				Name = "John",
				Age = 34,
				StateOfOrigin = "England",
				Pets = pets
			};

			Console.WriteLine(JsonSerializer.Serialize(person));
			Console.WriteLine(JsonSerializer.Serialize<Person>(person));
		}

		private static async Task SerializeToFile()
		{
			var pets = new List<Pet>
			{
				new Pet { Type = "Cat", Name = "MooMoo", Age = 3.4 },
				new Pet { Type = "Squirrel", Name = "Sandy", Age = 7}
			};

			var person = new Person
			{
				Name = "John",
				Age = 34,
				StateOfOrigin = "England",
				Pets = pets
			};

			var fileName = "Person.json";

			using var stream = File.Create(fileName);
			await JsonSerializer.SerializeAsync(stream, person);
			await stream.DisposeAsync();

			Console.WriteLine(File.ReadAllText(fileName));
		}

		private static void DeserizalizeExample()
		{
			var jsonPerson = @"{""Name"":""John"",
								""Age"":34,
								""StateOfOrigin"":""England"",
								""Pets"":
									[{""Type"":""Cat"",""Name"":""MooMoo"",""Age"":3.4},
									{""Type"":""Squirrel"",""Name"":""Sandy"",""Age"":7}]}";

			var personObject = JsonSerializer.Deserialize<Person>(jsonPerson);

			Console.WriteLine($"Person's name: {personObject.Name}");
			Console.WriteLine($"Person's age: {personObject.Age}");
			Console.WriteLine($"Person's first pet's name: {personObject.Pets.First().Name}");
		}

		private static void DeserializeWithJsonDocument()
		{
			var unknownJsonStructure = @"{""Product name"":""Fork"",
											""Price"": ""300$"",
											""Categories"":
												[{""Area"":""Kitchen"",""Description"":""Cooking Utensil""},
												{""Area"":""Dinning room"",""Description"":""Dinning Utensil""}]}";

			var unknownObject = JsonDocument.Parse(unknownJsonStructure);
			var productName = unknownObject.RootElement.GetProperty("Product name");

			Console.WriteLine($"Product name: {productName}");

			var categories = unknownObject.RootElement.GetProperty("Categories");

			Console.WriteLine("Categories: ");

			foreach (var category in categories.EnumerateArray())
			{
				Console.WriteLine(category.GetProperty("Area"));
			}
		}

		private static void SerializeWithOptions()
		{
			var pets = new List<Pet>
			{
				new Pet { Type = "Cat", Name = "MooMoo", Age = 3.4 },
				new Pet { Type = "Squirrel", Name = "Sandy", Age = 7}
			};

			var person = new Person
			{
				Name = "John",
				Age = 34,
				StateOfOrigin = "England",
				Pets = pets
			};

			//var person2 = new Person
			//{
			//	Name = "John",
			//	Age = null,
			//	StateOfOrigin = "England",
			//	Pets = pets
			//};

			var options = new JsonSerializerOptions
			{
				WriteIndented = true, 
				IgnoreNullValues = true
			};

			Console.WriteLine(JsonSerializer.Serialize(person, options));
			//Console.WriteLine(JsonSerializer.Serialize(person2, options));
		}

		private static void DeserizalizeWithOptions()
		{
			var jsonPerson = @"{""Name"":""John"",
								""Age"":""34"",
								""StateOfOrigin"":""England"",
								""Pets"":
									[{""Type"":""Cat"",""Name"":""MooMoo"",""Age"":""3.4""},
									{""Type"":""Squirrel"",""Name"":""Sandy"",""Age"":7}]}";

			var options = new JsonSerializerOptions
			{
				NumberHandling = JsonNumberHandling.AllowReadingFromString
			};

			var personObject = JsonSerializer.Deserialize<Person>(jsonPerson,  options);

			Console.WriteLine($"Person's age: {personObject.Age}");
			Console.WriteLine($"Person's first pet's name: {personObject.Pets.First().Age}");
		}

	}
}