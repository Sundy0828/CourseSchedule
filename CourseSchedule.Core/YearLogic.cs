using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSchedule.Models.Requests;
using CourseSchedule.Core.DBModel;
using Microsoft.Extensions.Logging;
using CourseSchedule.Models.Pagination;
using CourseSchedule.Models.Exceptions;

namespace CourseSchedule.Core
{
    public class YearLogic
    {
        private readonly ILogger<YearLogic> _logger;
        private readonly CourseScheduleDBContext _context;
        private readonly InstitutionLogic _institutionLogic;

        public YearLogic(ILogger<YearLogic> logger, CourseScheduleDBContext context, InstitutionLogic institutionLogic)
        {
            _logger = logger;
            _context = context;
            _institutionLogic = institutionLogic;
        }

        public PagedList<Year> GetAll(Guid institutionId, Pagination pagination)
        {
            _logger.LogInformation("Get all Years");

            return PagedList<Year>.ToPagedList(_context.Years.Where(d => d.Institution.Id == institutionId).OrderBy(d => d.Name),
                pagination.PageNumber,
                pagination.PageSize);
        }

        public Year Get(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Get Year {ID}", id);

            return _context.Years.Where(y => y.Id == id && y.Institution.Id == institutionId).FirstOrDefault() ?? throw new NotFoundException($"Year was not found with Id {id} and InstitutionId {institutionId}");
        }

        public Year Create(Guid institutionId, YearRequest y)
        {
            _logger.LogInformation("Create Year {Institusion}", y.Name);

            Institution institution = _institutionLogic.Get(institutionId);
            Year? exists = _context.Years.Where(x => x.Institution.Id == institutionId && x.Name == y.Name).FirstOrDefault();
            if (exists != null)
            {
                throw new BadRequestException($"Year already exists");
            }

            Year year = new()
            {
                Name = y.Name
            };

            institution.Years.Add(year);

            _context.Add(year);
            _context.SaveChanges();

            return year;
        }

        public Year PutUpdate(Guid institutionId, Guid id, YearRequest y)
        {
            _logger.LogInformation("Put Update {Institusion} {ID}", y.Name,  id);

            Year year = Get(institutionId, id);
            
            year.Name = y.Name;

            _context.Update(year);
            _context.SaveChanges();

            return year;
        }

        public void Delete(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Delete Year {ID}", id);

            Year year = Get(institutionId, id);

            _context.Remove(year);
            _context.SaveChanges();
        }
    }
}
