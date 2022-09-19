﻿using System;
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

            return _context.Disciplines.Where(d => d.Institution.Id == institutionId).OrderBy(d => d).ToList();
        }

        public Discipline Get(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Get Discipline {ID}", id);

            return _context.Disciplines.Where(d => d.Id == id && d.Institution.Id == institutionId).First();
        }

        public Discipline Create(Guid institutionId, DisciplineRequest d)
        {
            _logger.LogInformation("Create Discipline {Institusion}", d.Name);

            Institution institution = _context.Institutions.Where(i => i.Id == institutionId).First();

            Discipline discipline = new(d.Name, d.MajorCode, d.IsMajor);

            institution.AddDiscipline(discipline);

            _context.Add(discipline);
            _context.SaveChanges();

            return discipline;
        }

        public Discipline PutUpdate(Guid institutionId, Guid id, DisciplineRequest d)
        {
            _logger.LogInformation("Put Update {Institusion} {ID}", d.Name,  id);

            Discipline discipline = _context.Disciplines.Where(d => d.Id == id && d.Institution.Id == institutionId).First();
            discipline.Update(d.Name, d.MajorCode, d.IsMajor);

            _context.Update(discipline);
            _context.SaveChanges();

            return discipline;
        }

        public Discipline PatchUpdate(Guid institutionId, Guid id, DisciplineRequest d)
        {
            _logger.LogInformation("Patch Update {Institusion} {ID}", d.Name, id);

            Discipline discipline = _context.Disciplines.Where(d => d.Id == id && d.Institution.Id == institutionId).First();
            discipline.Update(d.Name, d.MajorCode, d.IsMajor);

            _context.Update(discipline);
            _context.SaveChanges();

            return discipline;
        }

        public Discipline Delete(Guid institutionId, Guid id)
        {
            _logger.LogInformation("Delete Discipline {ID}", id);

            Discipline discipline = _context.Disciplines.Where(d => d.Id == id && d.Institution.Id == institutionId).First();

            _context.Remove(discipline);
            _context.SaveChanges();

            return discipline;
        }
    }
}
