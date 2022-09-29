using System.Net;
using CourseSchedule.Models.Requests;
using CourseSchedule.Models.Response;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using CourseSchedule.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using CourseSchedule.Models.Exceptions;

namespace CourseSchedule.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Unauthorized Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Forbidden Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Item was not found", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Internal Server Error", Type = typeof(ErrorDetails))]
    [AllowAnonymous]
    public class PublicController : ControllerBase
    {
        private readonly ILogger<PublicController> _logger;

        public PublicController(ILogger<PublicController> logger)
        {
            _logger = logger;
        }

        [HttpPost("token")]
        [SwaggerOperation(
            Summary = "Retrieves token",
            Description = "This endpoint a bearer token with the public and secret keys.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a token.", Type = typeof(InstitutionResponse))]
        public IActionResult Get([FromBody] TokenRequest t)
        {
            return Ok();
        }
    }
}
