using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
	[ExcludeFromCodeCoverage]
	[Route("api/[controller]")]
	[ApiController]
	public class HealthController : ControllerBase
	{
		[ApiExplorerSettings(IgnoreApi = true)]
		[Route("/error")]
		public IActionResult HandleError() => Problem();
	}
}
