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

    [Route("Combinations")]
    [Authorize]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Unauthorized Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Forbidden Request", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Item was not found", Type = typeof(ErrorDetails))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Internal Server Error", Type = typeof(ErrorDetails))]
    public class CombinationsController : ControllerBase
    {
        //private readonly ILogger<CombinationsController> _logger;
        //private readonly CombinationLogic _logic;

        //public CombinationsController(ILogger<CombinationsController> logger, CombinationLogic logic)
        //{
        //    _logger = logger;
        //    _logic = logic;
        //}

        //[HttpPost]
        //[SwaggerOperation(
        //    Summary = "Creates a new combination",
        //    Description = "This endpoint allows the create of a new combination.")]
        //[SwaggerResponse((int)HttpStatusCode.Created, Description = "Returns a created combination.", Type = typeof(CombinationResponse))]
        //public IActionResult Create([FromBody] CombinationRequest combination)
        //{
        //    return Created("", _logic.Create(combination));
        //}

        //[HttpGet]
        //[SwaggerOperation(
        //    Summary = "Gets all combinations",
        //    Description = "This endpoint allows the retreival of a list of combinations.")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all combinations.", Type = typeof(PagedList<CombinationResponse>))]
        //public IActionResult Get(Guid YearId, [FromQuery] CombinationPagination pagination)
        //{
        //    var pagedCombination = _logic.GetAll(pagination);

        //    var metadata = new
        //    {
        //        pagedCombination.TotalCount,
        //        pagedCombination.PageSize,
        //        pagedCombination.CurrentPage,
        //        pagedCombination.TotalPages,
        //        pagedCombination.HasNext,
        //        pagedCombination.HasPrevious
        //    };

        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        //    return Ok(pagedCombination);
        //}

        //[HttpGet("{CombinationId}")]
        //[SwaggerOperation(
        //    Summary = "Retrieves an combination",
        //    Description = "This endpoint allows the retrieval of a single combination.")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a single combination.", Type = typeof(CombinationResponse))]
        //public IActionResult Get(Guid CombinationId)
        //{
        //    return Ok(_logic.Get(CombinationId));
        //}

        //[HttpPatch("{CombinationId}")]
        //[SwaggerOperation(
        //    Summary = "Updates an existing combination",
        //    Description = "This endpoint allows the update of an existing combination.")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated combination.", Type = typeof(CombinationResponse))]
        //public IActionResult Patch(Guid CombinationId, [FromBody] CombinationRequest combination)
        //{
        //    return Ok(_logic.PatchUpdate(CombinationId, combination));
        //}

        //[HttpPut("{CombinationId}")]
        //[SwaggerOperation(
        //    Summary = "Updates an existing combination",
        //    Description = "This endpoint allows the update of an existing combination.")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated combination.", Type = typeof(CombinationResponse))]
        //public IActionResult Put(Guid CombinationId, [FromBody] CombinationRequest combination)
        //{
        //    return Ok(_logic.PutUpdate( CombinationId, combination));
        //}

        //[HttpDelete("{CombinationId}")]
        //[SwaggerOperation(
        //    Summary = "Deletes an combination",
        //    Description = "This endpoint allows the deletion of an combination.")]
        //[SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Successfully deleted the field.")]
        //public IActionResult Delete(Guid CombinationId)
        //{
        //    _logic.Delete(CombinationId);
        //    return NoContent();
        //}
    }
}
