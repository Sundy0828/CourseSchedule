using System.Net;
using CourseSchedule.Models.Requests;
using CourseSchedule.Models.Response;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseSchedule.API.Controllers
{
    [ApiController]

    [Route("Institutions/{InstitutionId}/Disciplines")]
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
        public IActionResult Create(Guid InstitutionId, [FromBody] DisciplineRequest discipline)
        {
            return Created("", _logic.Create(InstitutionId, discipline));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all disciplines",
            Description = "This endpoint allows the retreival of a list of disciplines.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all disciplines.", Type = typeof(PagedList<DisciplineResponse>))]
        public IActionResult Get(Guid InstitutionId, [FromQuery] DisciplinePagination pagination)
        {
            var pagedDiscipline = _logic.GetAll(InstitutionId, pagination);

            var metadata = new
            {
                pagedDiscipline.TotalCount,
                pagedDiscipline.PageSize,
                pagedDiscipline.CurrentPage,
                pagedDiscipline.TotalPages,
                pagedDiscipline.HasNext,
                pagedDiscipline.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(pagedDiscipline);
        }

        [HttpGet("{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Retrieves an discipline",
            Description = "This endpoint allows the retrieval of a single discipline.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a single discipline.", Type = typeof(DisciplineResponse))]
        public IActionResult Get(Guid InstitutionId, Guid DisciplineId)
        {
            return Ok(_logic.Get(InstitutionId, DisciplineId));
        }

        [HttpPatch("{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Updates an existing discipline",
            Description = "This endpoint allows the update of an existing discipline.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated discipline.", Type = typeof(DisciplineResponse))]
        public IActionResult Patch(Guid InstitutionId, Guid DisciplineId, [FromBody] DisciplineRequest discipline)
        {
            return Ok(_logic.PatchUpdate(InstitutionId, DisciplineId, discipline));
        }

        [HttpPut("{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Updates an existing discipline",
            Description = "This endpoint allows the update of an existing discipline.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated discipline.", Type = typeof(DisciplineResponse))]
        public IActionResult Put(Guid InstitutionId, Guid DisciplineId, [FromBody] DisciplineRequest discipline)
        {
            return Ok(_logic.PutUpdate(InstitutionId, DisciplineId, discipline));
        }

        [HttpDelete("{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Deletes an discipline",
            Description = "This endpoint allows the deletion of an discipline.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Successfully deleted the field.")]
        public IActionResult Delete(Guid InstitutionId, Guid DisciplineId)
        {
            _logic.Delete(InstitutionId, DisciplineId);
            return NoContent();
        }
    }
}
