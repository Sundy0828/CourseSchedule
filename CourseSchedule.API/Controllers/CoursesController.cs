using System.Net;
using CourseSchedule.Models.Requests;
using CourseSchedule.Models.Response;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using CourseSchedule.Models.Pagination;

namespace CourseSchedule.API.Controllers
{
    [ApiController]

    [Route("Disciplines/{DisciplineId}/Courses")]
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
        public IActionResult Create(Guid DisciplineId, [FromBody] CourseRequest course)
        {
            return Created("", _logic.Create(DisciplineId, course));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all courses",
            Description = "This endpoint allows the retreival of a list of courses.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all courses.", Type = typeof(PagedList<CourseResponse>))]
        public IActionResult Get(Guid DisciplineId, [FromQuery] CoursePagination pagination)
        {
            var pagedCourse = _logic.GetAll(DisciplineId, pagination);

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
        public IActionResult Get(Guid DisciplineId, Guid CourseId)
        {
            return Ok(_logic.Get(DisciplineId, CourseId));
        }

        [HttpPatch("{CourseId}")]
        [SwaggerOperation(
            Summary = "Updates an existing course",
            Description = "This endpoint allows the update of an existing course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated course.", Type = typeof(CourseResponse))]
        public IActionResult Patch(Guid DisciplineId, Guid CourseId, [FromBody] CourseRequest course)
        {
            return Ok(_logic.PatchUpdate(DisciplineId, CourseId, course));
        }

        [HttpPut("{CourseId}")]
        [SwaggerOperation(
            Summary = "Updates an existing course",
            Description = "This endpoint allows the update of an existing course.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated course.", Type = typeof(CourseResponse))]
        public IActionResult Put(Guid DisciplineId, Guid CourseId, [FromBody] CourseRequest course)
        {
            return Ok(_logic.PutUpdate(DisciplineId, CourseId, course));
        }

        [HttpDelete("{CourseId}")]
        [SwaggerOperation(
            Summary = "Deletes an course",
            Description = "This endpoint allows the deletion of an course.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Successfully deleted the field.")]
        public IActionResult Delete(Guid DisciplineId, Guid CourseId)
        {
            _logic.Delete(DisciplineId, CourseId);
            return NoContent();
        }
    }
}
