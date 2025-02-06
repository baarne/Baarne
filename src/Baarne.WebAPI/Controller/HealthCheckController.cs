using Baarne.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Baarne.WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ITestService _testService;
        public HealthCheckController(ITestService testService)
        {
            _testService = testService;
        }
        
        [HttpGet("status")]
        public IActionResult Get()
        {
            return Ok("API çalışıyor!!!");
        }

        [HttpGet("dependency")]
        public IActionResult CheckDependency()
        {
            return Ok(_testService.GetStatus());
        }
    }
}