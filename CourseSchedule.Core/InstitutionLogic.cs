using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSchedule.API.Models.Requests;
using CourseSchedule.Core.DBModel;
using Microsoft.Extensions.Logging;

namespace CourseSchedule.Core
{
    public class InstitutionLogic
    {
        private readonly ILogger<InstitutionLogic> _logger;
        private readonly CourseScheduleDBContext _context;

        public InstitutionLogic(ILogger<InstitutionLogic> logger, CourseScheduleDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Institution> GetAll(Pagination pagination)
        {
            _logger.LogInformation("Get all institutions");

            return _context.Institutions
                .OrderBy(i => i.Name)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();
        }

        public Institution Get(Guid id)
        {
            _logger.LogInformation("Get institution {ID}", id);

            return _context.Institutions.Where(i => i.Id == id).First();
        }

        public Institution Create(InstitutionRequest i)
        {
            _logger.LogInformation("Create institution {Institusion}", i.Name);

            Institution institution = new(i.Name);

            _context.Add(institution);
            _context.SaveChanges();

            return institution;
        }

        public Institution PutUpdate(Guid id, InstitutionRequest i)
        {
            _logger.LogInformation("Put Update {Institusion} {ID}", i.Name, id);

            Institution institution = _context.Institutions.Where(i => i.Id == id).First();
            institution.Update(i.Name);

            _context.Update(institution);
            _context.SaveChanges();

            return institution;
        }

        public Institution PatchUpdate(Guid id, InstitutionRequest i)
        {
            _logger.LogInformation("Patch Update {Institusion} {ID}", i.Name, id);

            Institution institution = _context.Institutions.Where(i => i.Id == id).First();
            institution.Update(i.Name);

            _context.Update(institution);
            _context.SaveChanges();

            return institution;
        }

        public Institution Delete(Guid id)
        {
            _logger.LogInformation("Delete institution {ID}", id);

            Institution institution = _context.Institutions.Where(i => i.Id == id).First();

            _context.Remove(institution);
            _context.SaveChanges();

            return institution;
        }
    }
}
