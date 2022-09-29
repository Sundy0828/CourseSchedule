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
    public class SemesterLogic
    {
        private readonly ILogger<SemesterLogic> _logger;
        private readonly CourseScheduleDBContext _context;
        private readonly InstitutionLogic _institutionLogic;

        public SemesterLogic(ILogger<SemesterLogic> logger, CourseScheduleDBContext context, InstitutionLogic institutionLogic)
        {
            _logger = logger;
            _context = context;
            _institutionLogic = institutionLogic;
        }

        public PagedList<Semester> GetAll(Guid institutionId, Pagination pagination)
        {
            _logger.LogInformation("Get all Semesters");

            return PagedList<Semester>.ToPagedList(_context.Semesters.Where(d => d.Institution.Id == institutionId).OrderBy(d => d.Name),
                pagination.PageNumber,
                pagination.PageSize);
        }

        public Semester Get(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Get Semester {ID}", id);

            return _context.Semesters.Where(y => y.Id == id && y.Institution.Id == institutionId).FirstOrDefault() ?? throw new NotFoundException($"Semester was not found with Id {id} and InstitutionId {institutionId}");
        }

        public Semester Create(Guid institutionId, SemesterRequest y)
        {
            _logger.LogInformation("Create Semester {Institusion}", y.Name);

            Institution institution = _institutionLogic.Get(institutionId);
            Semester? exists = _context.Semesters.Where(x => x.Institution.Id == institutionId && x.Name == y.Name).FirstOrDefault();
            if (exists != null)
            {
                throw new BadRequestException($"Semester already exists");
            }

            Semester semester = new()
            {
                Name = y.Name
            };

            institution.Semesters.Add(semester);

            _context.Add(semester);
            _context.SaveChanges();

            return semester;
        }

        public Semester PutUpdate(Guid institutionId, Guid id, SemesterRequest y)
        {
            _logger.LogInformation("Put Update {Institusion} {ID}", y.Name,  id);

            Semester semester = Get(institutionId, id);
            
            semester.Name = y.Name;

            _context.Update(semester);
            _context.SaveChanges();

            return semester;
        }

        public void Delete(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Delete Semester {ID}", id);

            Semester semester = Get(institutionId, id);

            _context.Remove(semester);
            _context.SaveChanges();
        }
    }
}
