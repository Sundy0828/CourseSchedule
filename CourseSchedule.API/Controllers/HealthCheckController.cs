using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseSchedule.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/healthz")]
        public IActionResult Healthz() => this.Get();

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("core")]
        [AllowAnonymous]
        public IActionResult CoreServices([FromServices] CourseScheduleDBContext dBContext)
        {
            try
            {
                dBContext.Database.EnsureCreated();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Found error while checking core services: {errorMessage}", ex.Message);
                return BadRequest();
            }
        }
    }
}
