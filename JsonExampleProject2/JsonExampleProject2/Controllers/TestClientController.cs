using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace JsonExampleProject2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestClientController : ControllerBase
	{
		private static IHttpClientFactory _httpClient;

		public TestClientController(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}

		[HttpGet]
		public async Task<IActionResult> GetJson()
		{
			var client = _httpClient.CreateClient("TestClientController");
			var person = await client.GetFromJsonAsync<Person>("Test");

			return Ok(person);
		}
	}
}
