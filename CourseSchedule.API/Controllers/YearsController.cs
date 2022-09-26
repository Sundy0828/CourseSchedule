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

    [Route("Institutions/{InstitutionId}/Years")]
    public class YearsController : ControllerBase
    {
        private readonly ILogger<YearsController> _logger;
        private readonly YearLogic _logic;

        public YearsController(ILogger<YearsController> logger, YearLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new year",
            Description = "This endpoint allows the create of a new year.")]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Returns a created year.", Type = typeof(YearResponse))]
        public IActionResult Create(Guid InstitutionId, [FromBody] YearRequest year)
        {
            return Created("", _logic.Create(InstitutionId, year));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all years",
            Description = "This endpoint allows the retreival of a list of years.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all years.", Type = typeof(PagedList<YearResponse>))]
        public IActionResult Get(Guid InstitutionId, [FromQuery] YearPagination pagination)
        {
            var pagedYear = _logic.GetAll(InstitutionId, pagination);

            var metadata = new
            {
                pagedYear.TotalCount,
                pagedYear.PageSize,
                pagedYear.CurrentPage,
                pagedYear.TotalPages,
                pagedYear.HasNext,
                pagedYear.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(pagedYear);
        }

        [HttpGet("{YearId}")]
        [SwaggerOperation(
            Summary = "Retrieves an year",
            Description = "This endpoint allows the retrieval of a single year.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a single year.", Type = typeof(YearResponse))]
        public IActionResult Get(Guid InstitutionId, Guid YearId)
        {
            return Ok(_logic.Get(InstitutionId, YearId));
        }

        [HttpPut("{YearId}")]
        [SwaggerOperation(
            Summary = "Updates an existing year",
            Description = "This endpoint allows the update of an existing year.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated year.", Type = typeof(YearResponse))]
        public IActionResult Put(Guid InstitutionId, Guid YearId, [FromBody] YearRequest year)
        {
            return Ok(_logic.PutUpdate(InstitutionId, YearId, year));
        }

        [HttpDelete("{YearId}")]
        [SwaggerOperation(
            Summary = "Deletes an year",
            Description = "This endpoint allows the deletion of an year.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Successfully deleted the field.")]
        public IActionResult Delete(Guid InstitutionId, Guid YearId)
        {
            _logic.Delete(InstitutionId, YearId);
            return NoContent();
        }
    }
}
