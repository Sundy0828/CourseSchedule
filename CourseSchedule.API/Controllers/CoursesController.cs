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

    [Route("Courses")]
    [Authorize]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Unauthorized Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Forbidden Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Item was not found", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Internal Server Error", Type = typeof(ErrorDetails))]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly CourseLogic _logic;

        public CoursesController(ILogger<CoursesController> logger, CourseLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new course",
            Description = "This endpoint allows the create of a new course.")]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Returns a created course.", Type = typeof(CourseResponse))]
        public IActionResult Create([FromBody] CourseRequest course)
        {
            return Created("", _logic.Create(course));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all courses",
            Description = "This endpoint allows the retreival of a list of courses.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all courses.", Type = typeof(PagedList<CourseResponse>))]
        public IActionResult Get(Guid YearId, [FromQuery] CoursePagination pagination)
        {
            var pagedCourse = _logic.GetAll(pagination);

            var metadata = new
            {
                pagedCourse.TotalCount,
                pagedCourse.PageSize,
                pagedCourse.CurrentPage,
                pagedCourse.TotalPages,
                pagedCourse.HasNext,
                pagedCourse.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(pagedCourse);
        }

        [HttpGet("{CourseId}")]
        [SwaggerOperation(
            Summary = "Retrieves an course",
            Description = "This endpoint allows the retrieval of a single course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a single course.", Type = typeof(CourseResponse))]
        public IActionResult Get(Guid CourseId)
        {
            return Ok(_logic.Get(CourseId));
        }

        [HttpPatch("{CourseId}")]
        [SwaggerOperation(
            Summary = "Updates an existing course",
            Description = "This endpoint allows the update of an existing course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated course.", Type = typeof(CourseResponse))]
        public IActionResult Patch(Guid CourseId, [FromBody] CourseRequest course)
        {
            return Ok(_logic.PatchUpdate(CourseId, course));
        }

        [HttpPut("{CourseId}")]
        [SwaggerOperation(
            Summary = "Updates an existing course",
            Description = "This endpoint allows the update of an existing course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated course.", Type = typeof(CourseResponse))]
        public IActionResult Put(Guid CourseId, [FromBody] CourseRequest course)
        {
            return Ok(_logic.PutUpdate( CourseId, course));
        }

        [HttpDelete("{CourseId}")]
        [SwaggerOperation(
            Summary = "Deletes an course",
            Description = "This endpoint allows the deletion of an course.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Successfully deleted the field.")]
        public IActionResult Delete(Guid CourseId)
        {
            _logic.Delete(CourseId);
            return NoContent();
        }

        [HttpPost("{CourseId}/Year/{YearId}")]
        [SwaggerOperation(
            Summary = "Adds a year as a requirement for a course",
            Description = "This endpoint adds a year as a requirement for a course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Successfully added year to course.")]
        public IActionResult AddCourse(Guid CourseId, Guid YearId)
        {
            _logic.AddYear(CourseId, YearId);
            return Ok();
        }

        [HttpDelete("{CourseId}/Year/{YearId}")]
        [SwaggerOperation(
            Summary = "Removes a year as a requirement for a course",
            Description = "This endpoint removes a year as a requirement for a course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Successfully removed year from course.")]
        public IActionResult DeleteCourse(Guid CourseId, Guid YearId)
        {
            _logic.RemoveYear(CourseId, YearId);
            return Ok();
        }

        [HttpPost("{CourseId}/Semester/{SemesterId}")]
        [SwaggerOperation(
            Summary = "Adds a semester as a requirement for a course",
            Description = "This endpoint adds a semester as a requirement for a course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Successfully added semester to course.")]
        public IActionResult AddSemester(Guid CourseId, Guid SemesterId)
        {
            _logic.AddSemester(CourseId, SemesterId);
            return Ok();
        }

        [HttpDelete("{CourseId}/Semester/{SemesterId}")]
        [SwaggerOperation(
            Summary = "Removes a semester as a requirement for a course",
            Description = "This endpoint removes a semester as a requirement for a course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Successfully removed semester from course.")]
        public IActionResult DeleteSemester(Guid CourseId, Guid SemesterId)
        {
            _logic.RemoveSemester(CourseId, SemesterId);
            return Ok();
        }
    }
}
