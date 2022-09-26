using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSchedule.Models.Requests;
using CourseSchedule.Core.DBModel;
using Microsoft.Extensions.Logging;
using System.Data.Entity;
using CourseSchedule.Models.Pagination;
using CourseSchedule.Models.Exceptions;

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

        public PagedList<Institution> GetAll(Pagination pagination)
        {
            _logger.LogInformation("Get all institutions");

            return PagedList<Institution>.ToPagedList(_context.Institutions.OrderBy(on => on.Name),
                pagination.PageNumber,
                pagination.PageSize);
        }

        public Institution Get(Guid id)
        {
            _logger.LogInformation("Get institution {ID}", id);

            return _context.Institutions.Include(i => i.Disciplines).Where(i => i.Id == id).FirstOrDefault() ?? throw new NotFoundException($"Institution with Id {id} was not found");
        }

        public Institution Create(InstitutionRequest i)
        {
            _logger.LogInformation("Create institution {Institusion}", i.Name);

            Institution institution = new()
            {
                Name = i.Name
            };

            _context.Add(institution);
            _context.SaveChanges();

            return institution;
        }

        public Institution PutUpdate(Guid id, InstitutionRequest i)
        {
            _logger.LogInformation("Put Update {Institusion} {ID}", i.Name, id);

            Institution institution = _context.Institutions.Where(i => i.Id == id).FirstOrDefault() ?? throw new NotFoundException($"Institution with Id {id} was not found");

            institution.Name = i.Name;

            _context.Update(institution);
            _context.SaveChanges();

            return institution;
        }

        public Institution PatchUpdate(Guid id, InstitutionRequest i)
        {
            _logger.LogInformation("Patch Update {Institusion} {ID}", i.Name, id);

            Institution institution = _context.Institutions.Where(i => i.Id == id).FirstOrDefault() ?? throw new NotFoundException($"Institution with Id {id} was not found");

            institution.Name = i.Name;

            _context.Update(institution);
            _context.SaveChanges();

            return institution;
        }

        public void Delete(Guid id)
        {
            _logger.LogInformation("Delete institution {ID}", id);

            Institution institution = _context.Institutions.Where(i => i.Id == id).FirstOrDefault() ?? throw new NotFoundException($"Institution with Id {id} was not found");

            _context.Remove(institution);
            _context.SaveChanges();
        }
    }
}
