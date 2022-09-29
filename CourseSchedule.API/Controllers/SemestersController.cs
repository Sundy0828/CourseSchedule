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
    [Route("Institutions/{InstitutionId}/Semesters")]
    public class SemestersController : ControllerBase
    {
        private readonly ILogger<SemestersController> _logger;
        private readonly SemesterLogic _logic;

        public SemestersController(ILogger<SemestersController> logger, SemesterLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new semester",
            Description = "This endpoint allows the create of a new semester.")]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Returns a created semester.", Type = typeof(SemesterResponse))]
        public IActionResult Create(Guid InstitutionId, [FromBody] SemesterRequest semester)
        {
            return Created("", _logic.Create(InstitutionId, semester));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all semesters",
            Description = "This endpoint allows the retreival of a list of semesters.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all semesters.", Type = typeof(PagedList<SemesterResponse>))]
        public IActionResult Get(Guid InstitutionId, [FromQuery] SemesterPagination pagination)
        {
            var pagedSemester = _logic.GetAll(InstitutionId, pagination);

            var metadata = new
            {
                pagedSemester.TotalCount,
                pagedSemester.PageSize,
                pagedSemester.CurrentPage,
                pagedSemester.TotalPages,
                pagedSemester.HasNext,
                pagedSemester.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(pagedSemester);
        }

        [HttpGet("{SemesterId}")]
        [SwaggerOperation(
            Summary = "Retrieves an semester",
            Description = "This endpoint allows the retrieval of a single semester.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a single semester.", Type = typeof(SemesterResponse))]
        public IActionResult Get(Guid InstitutionId, Guid SemesterId)
        {
            return Ok(_logic.Get(InstitutionId, SemesterId));
        }

        [HttpPut("{SemesterId}")]
        [SwaggerOperation(
            Summary = "Updates an existing semester",
            Description = "This endpoint allows the update of an existing semester.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated semester.", Type = typeof(SemesterResponse))]
        public IActionResult Put(Guid InstitutionId, Guid SemesterId, [FromBody] SemesterRequest semester)
        {
            return Ok(_logic.PutUpdate(InstitutionId, SemesterId, semester));
        }

        [HttpDelete("{SemesterId}")]
        [SwaggerOperation(
            Summary = "Deletes an semester",
            Description = "This endpoint allows the deletion of an semester.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Successfully deleted the field.")]
        public IActionResult Delete(Guid InstitutionId, Guid SemesterId)
        {
            _logic.Delete(InstitutionId, SemesterId);
            return NoContent();
        }
    }
}
