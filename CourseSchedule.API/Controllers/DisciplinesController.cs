using System.Net;
using CourseSchedule.Models.Requests;
using CourseSchedule.Models.Response;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using CourseSchedule.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using CourseSchedule.Models.Exceptions;

namespace CourseSchedule.API.Controllers
{
    [ApiController]
    [Authorize]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Unauthorized Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Forbidden Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Item was not found", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Internal Server Error", Type = typeof(ErrorDetails))]
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

        [HttpPost("{DisciplineId}/Course/{CourseId}")]
        [SwaggerOperation(
            Summary = "Adds a course as a requirement for a discipline",
            Description = "This endpoint adds a course as a requirement for a discipline.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated discipline.")]
        public IActionResult AddCourse(Guid DisciplineId, Guid CourseId)
        {
            _logic.AddCourse(DisciplineId, CourseId);
            return Ok();
        }

        [HttpDelete("{DisciplineId}/Course/{CourseId}")]
        [SwaggerOperation(
            Summary = "Removes a course as a requirement for a discipline",
            Description = "This endpoint removes a course as a requirement for a discipline.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated discipline.")]
        public IActionResult DeleteCourse(Guid DisciplineId, Guid CourseId)
        {
            _logic.RemoveCourse(DisciplineId, CourseId);
            return Ok();
        }
    }
}
