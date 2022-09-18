using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSchedule.API.Models.Creation;
using CourseSchedule.Core.DBModel;
using Microsoft.Extensions.Logging;

namespace CourseSchedule.Core
{
    public class DisciplineLogic
    {
        private readonly ILogger<DisciplineLogic> _logger;
        private readonly CourseScheduleDBContext _context;

        public DisciplineLogic(ILogger<DisciplineLogic> logger, CourseScheduleDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Discipline> GetAll(Guid institutionId)
        {
            _logger.LogInformation("Get all Disciplines");

            return _context.Disciplines.Where(d => d.InstitutionId == institutionId).OrderBy(d => d).ToList();
        }

        public Discipline Get(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Get Discipline {ID}", id);

            return _context.Disciplines.Where(d => d.Id == id && d.InstitutionId == institutionId).First();
        }

        public Discipline Create(Guid institutionId, DisciplineRequest d)
        {
            _logger.LogInformation("Create Discipline {Institusion}", d.Name);

            Discipline Discipline = new(institutionId, d.Name, d.MajorCode, d.IsMajor);

            _context.Add(Discipline);
            _context.SaveChanges();

            return Discipline;
        }

        public Discipline Update(Guid institutionId, Guid id, DisciplineRequest d)
        {
            _logger.LogInformation("Update {Institusion} {ID}", d.Name,  id);

            Discipline Discipline = _context.Disciplines.Where(d => d.Id == id && d.InstitutionId == institutionId).First();
            Discipline.Update(institutionId, d.Name, d.MajorCode, d.IsMajor);

            _context.Update(Discipline);
            _context.SaveChanges();

            return Discipline;
        }

        public Discipline Delete(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Delete Discipline {ID}", id);

            Discipline Discipline = _context.Disciplines.Where(d => d.Id == id && d.InstitutionId == institutionId).First();

            _context.Remove(Discipline);
            _context.SaveChanges();

            return Discipline;
        }
    }
}
