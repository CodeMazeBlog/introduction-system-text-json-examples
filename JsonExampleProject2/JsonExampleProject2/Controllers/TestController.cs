using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonExampleProject2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet]
		public string Get()
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

			var options = new JsonSerializerOptions
			{
				WriteIndented = true
			};

			return JsonSerializer.Serialize(person, options);
		}
	}
}
