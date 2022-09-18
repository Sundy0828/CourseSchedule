using System.Net;
using CourseSchedule.API.Models.Creation;
using CourseSchedule.API.Models.Response;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseSchedule.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinesController : ControllerBase
    {
        private readonly ILogger<DisciplinesController> _logger;
        private readonly DisciplineLogic _logic;

        public DisciplinesController(ILogger<DisciplinesController> logger, DisciplineLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new discipline",
            Description = "This endpoint allows the create of a new discipline.")]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Returns a created discipline.", Type = typeof(DisciplineResponse))]
        public IActionResult Create([FromBody] DisciplineRequest discipline)
        {
            return Ok(_logic.Create(discipline));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all disciplines",
            Description = "This endpoint allows the retreival of a list of disciplines.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all disciplines.", Type = typeof(DisciplineCollection))]
        public IActionResult Get()
        {
            return Ok(_logic.GetAll());
        }

        [HttpGet("{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Retrieves an discipline",
            Description = "This endpoint allows the retrieval of a single discipline.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a single discipline.", Type = typeof(DisciplineResponse))]
        public IActionResult Get(Guid DisciplineId)
        {
            return Ok(_logic.Get(DisciplineId));
        }

        [HttpPatch("{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Updates an existing discipline",
            Description = "This endpoint allows the update of an existing discipline.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated discipline.", Type = typeof(DisciplineResponse))]
        public IActionResult Patch(Guid DisciplineId, [FromBody] DisciplineRequest discipline)
        {
            return Ok(_logic.Update(DisciplineId, discipline));
        }

        [HttpPut("{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Updates an existing discipline",
            Description = "This endpoint allows the update of an existing discipline.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated discipline.", Type = typeof(DisciplineResponse))]
        public IActionResult Put(Guid DisciplineId, [FromBody] DisciplineRequest discipline)
        {
            return Ok(_logic.Update(DisciplineId, discipline));
        }

        [HttpDelete("{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Deletes an discipline",
            Description = "This endpoint allows the deletion of an discipline.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Successfully deleted the field.")]
        public IActionResult Delete(Guid DisciplineId)
        {
            return Ok(_logic.Delete(DisciplineId));
        }
    }
}
