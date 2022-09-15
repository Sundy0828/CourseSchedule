using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Microsoft.AspNetCore.Mvc;

namespace CourseSchedule.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionsController : ControllerBase
    {
        private readonly ILogger<InstitutionsController> _logger;
        private readonly InstitutionLogic _logic;

        public InstitutionsController(ILogger<InstitutionsController> logger, InstitutionLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpPost]
        public Institutions Create(string Name)
        {
            return _logic.Create(Name);
        }

        [HttpGet]
        public List<Institutions> Get()
        {
            return _logic.Get();
        }
    }
}
