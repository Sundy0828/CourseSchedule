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

        public List<Discipline> GetAll()
        {
            _logger.LogInformation("Get all Disciplines");

            return _context.Disciplines.OrderBy(d => d).ToList();
        }

        public Discipline Get(Guid id)
        {
            _logger.LogInformation("Get Discipline {ID}", id);

            return _context.Disciplines.Where(i => i.Id == id).First();
        }

        public Discipline Create(DisciplineRequest d)
        {
            _logger.LogInformation("Create Discipline {Institusion}", d.Name);

            Discipline Discipline = new(d.Name, d.IsMajor);

            _context.Add(Discipline);
            _context.SaveChanges();

            return Discipline;
        }

        public Discipline Update(Guid id, DisciplineRequest d)
        {
            _logger.LogInformation("Update {Institusion} {ID}", d.Name,  id);

            Discipline Discipline = _context.Disciplines.Where(i => i.Id == id).First();
            Discipline.Update(d.Name, d.IsMajor);

            _context.Update(Discipline);
            _context.SaveChanges();

            return Discipline;
        }

        public Discipline Delete(Guid id)
        {
            _logger.LogInformation("Delete Discipline {ID}", id);

            Discipline Discipline = _context.Disciplines.Where(i => i.Id == id).First();

            _context.Remove(Discipline);
            _context.SaveChanges();

            return Discipline;
        }
    }
}
