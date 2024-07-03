using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hello_HNG_API_.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HelloController : ControllerBase
	{
		
			private readonly IHttpClientFactory _httpClientFactory;

			public HelloController (IHttpClientFactory httpClientFactory)
			{
				_httpClientFactory = httpClientFactory;
			}

			[HttpGet]
			public async Task<IActionResult> Get([FromQuery] string visitor_name)
			{
				string clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();
				string location = "New York";
				double temperature = 11;

				var response = new
				{
					client_ip = clientIp,
					location = location,
					greeting = $"Hello, {visitor_name}!, the temperature is {temperature} degrees Celsius in {location}"
				};

				return Ok(response);
			}
		
	}
}
