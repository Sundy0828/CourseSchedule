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

namespace CourseSchedule.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionsController : ControllerBase
    {
        private readonly ILogger<InstitutionsController> _logger;
        private readonly IMapper _mapper;
        private readonly InstitutionLogic _logic;

        public InstitutionsController(ILogger<InstitutionsController> logger, IMapper mapper, InstitutionLogic logic)
        {
            _logger = logger;
            _mapper = mapper;
            _logic = logic;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new institution",
            Description = "This endpoint allows the create of a new institution.")]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Returns a created institution.", Type = typeof(InstitutionResponse))]
        public IActionResult Create([FromBody] InstitutionRequest institution)
        {
            return Created("", _logic.Create(institution));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all institutions",
            Description = "This endpoint allows the retreival of a list of institutions.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all institutions.", Type = typeof(PagedList<InstitutionResponse>))]
        public IActionResult Get([FromQuery] InstitutionPagination pagination)
        {
            var pagedInstitution = _logic.GetAll(pagination);

            var metadata = new
            {
                pagedInstitution.TotalCount,
                pagedInstitution.PageSize,
                pagedInstitution.CurrentPage,
                pagedInstitution.TotalPages,
                pagedInstitution.HasNext,
                pagedInstitution.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(pagedInstitution);
        }

        [HttpGet("{InstitutionId}")]
        [SwaggerOperation(
            Summary = "Retrieves an institution",
            Description = "This endpoint allows the retrieval of a single institution.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a single institution.", Type = typeof(InstitutionResponse))]
        public IActionResult Get(Guid InstitutionId)
        {
            return Ok(_mapper.Map<InstitutionResponse>(_logic.Get(InstitutionId)));
        }

        [HttpPatch("{InstitutionId}")]
        [SwaggerOperation(
            Summary = "Updates an existing institution",
            Description = "This endpoint allows the update of an existing institution.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated institution.", Type = typeof(InstitutionResponse))]
        public IActionResult Patch(Guid InstitutionId, [FromBody] InstitutionRequest institution)
        {
            return Ok(_logic.PatchUpdate(InstitutionId, institution));
        }

        [HttpPut("{InstitutionId}")]
        [SwaggerOperation(
            Summary = "Updates an existing institution",
            Description = "This endpoint allows the update of an existing institution.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns an updated institution.", Type = typeof(InstitutionResponse))]
        public IActionResult Put(Guid InstitutionId, [FromBody] InstitutionRequest institution)
        {
            return Ok(_logic.PutUpdate(InstitutionId, institution));
        }

        [HttpDelete("{InstitutionId}")]
        [SwaggerOperation(
            Summary = "Deletes an institution",
            Description = "This endpoint allows the deletion of an institution.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Successfully deleted the field.")]
        public IActionResult Delete(Guid InstitutionId)
        {
            _logic.Delete(InstitutionId);
            return NoContent();
        }

        [HttpPost("{InstitutionId}/Discipline/{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Adds a discipline as a requirement for a institution",
            Description = "This endpoint adds a discipline as a requirement for a institution.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Successfully added discipline to institution.")]
        public IActionResult AddCourse(Guid InstitutionId, Guid DisciplineId)
        {
            _logic.AddDiscipline(InstitutionId, DisciplineId);
            return Ok();
        }

        [HttpDelete("{InstitutionId}/Discipline/{DisciplineId}")]
        [SwaggerOperation(
            Summary = "Removes a discipline as a requirement for a institution",
            Description = "This endpoint removes a discipline as a requirement for a institution.")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Successfully removed discipline from institution.")]
        public IActionResult DeleteCourse(Guid InstitutionId, Guid DisciplineId)
        {
            _logic.RemoveDiscipline(InstitutionId, DisciplineId);
            return Ok();
        }
    }
}
