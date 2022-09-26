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
    public class DisciplineLogic
    {
        private readonly ILogger<DisciplineLogic> _logger;
        private readonly CourseScheduleDBContext _context;
        private readonly InstitutionLogic _institutionLogic;

        public DisciplineLogic(ILogger<DisciplineLogic> logger, CourseScheduleDBContext context, InstitutionLogic institutionLogic)
        {
            _logger = logger;
            _context = context;
            _institutionLogic = institutionLogic;
        }

        public PagedList<Discipline> GetAll(Guid institutionId, Pagination pagination)
        {
            _logger.LogInformation("Get all Disciplines");

            return PagedList<Discipline>.ToPagedList(_context.Disciplines.Where(d => d.Institution.Id == institutionId).OrderBy(d => d.Name),
                pagination.PageNumber,
                pagination.PageSize);
        }

        public Discipline Get(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Get Discipline {ID}", id);

            return _context.Disciplines.Where(d => d.Id == id && d.Institution.Id == institutionId).FirstOrDefault() ?? throw new NotFoundException($"Discipline was not found with Id {id} and InstitutionId {institutionId}");
        }

        public Discipline Create(Guid institutionId, DisciplineRequest d)
        {
            _logger.LogInformation("Create Discipline {Institusion}", d.Name);

            Institution institution = _institutionLogic.Get(institutionId);

            Discipline discipline = new(institution)
            {
                Name = d.Name,
                MajorCode = d.MajorCode,
                IsMajor = d.IsMajor
            };

            institution.Disciplines.Add(discipline);

            _context.Add(discipline);
            _context.SaveChanges();

            return discipline;
        }

        public Discipline PutUpdate(Guid institutionId, Guid id, DisciplineRequest d)
        {
            _logger.LogInformation("Put Update {Institusion} {ID}", d.Name,  id);

            Discipline discipline = _context.Disciplines.Where(d => d.Id == id && d.Institution.Id == institutionId).FirstOrDefault() ?? throw new NotFoundException($"Discipline was not found with Id {id} and InstitutionId {institutionId}");
            
            discipline.Name = d.Name;
            discipline.MajorCode = d.MajorCode;
            discipline.IsMajor = d.IsMajor;

            _context.Update(discipline);
            _context.SaveChanges();

            return discipline;
        }

        public Discipline PatchUpdate(Guid institutionId, Guid id, DisciplineRequest d)
        {
            _logger.LogInformation("Patch Update {Institusion} {ID}", d.Name, id);

            Discipline discipline = _context.Disciplines.Where(d => d.Id == id && d.Institution.Id == institutionId).FirstOrDefault() ?? throw new NotFoundException($"Discipline was not found with Id {id} and InstitutionId {institutionId}");

            discipline.Name = d.Name;
            discipline.MajorCode = d.MajorCode;
            discipline.IsMajor = d.IsMajor;

            _context.Update(discipline);
            _context.SaveChanges();

            return discipline;
        }

        public void Delete(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Delete Discipline {ID}", id);

            Discipline discipline = _context.Disciplines.Where(d => d.Id == id && d.Institution.Id == institutionId).FirstOrDefault() ?? throw new NotFoundException($"Discipline was not found with Id {id} and InstitutionId {institutionId}");

            _context.Remove(discipline);
            _context.SaveChanges();
        }
    }
}
