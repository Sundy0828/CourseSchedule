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

            Institution? exists = _context.Institutions.Where(x => x.Name == i.Name).FirstOrDefault();
            if (exists != null)
            {
                throw new BadRequestException($"Institution already exists");
            }

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

            Institution institution = Get(id);

            institution.Name = i.Name;

            _context.Update(institution);
            _context.SaveChanges();

            return institution;
        }

        public Institution PatchUpdate(Guid id, InstitutionRequest i)
        {
            _logger.LogInformation("Patch Update {Institusion} {ID}", i.Name, id);

            Institution institution = Get(id);

            institution.Name = i.Name;

            _context.Update(institution);
            _context.SaveChanges();

            return institution;
        }

        public void Delete(Guid id)
        {
            _logger.LogInformation("Delete institution {ID}", id);

            Institution institution = Get(id);

            _context.Remove(institution);
            _context.SaveChanges();
        }

        public void AddDiscipline(Guid id, Guid disciplineId)
        {
            _logger.LogInformation("Delete Discipline {ID}", id);

            Institution institution = Get(id);
            Discipline discipline = _context.Disciplines.Where(x => x.Id == disciplineId).FirstOrDefault() ?? throw new NotFoundException($"Discipline with Id {disciplineId} was not found");
            if (discipline.InstitutionId == id)
            {
                throw new BadRequestException($"Institution/Discipline connection was found with InstitutionId {id} and CourseId {disciplineId}");
            }

            institution.Disciplines.Add(discipline);

            _context.SaveChanges();
        }

        public void RemoveDiscipline(Guid id, Guid disciplineId)
        {
            _logger.LogInformation("Delete Discipline {ID}", id);

            Institution institution = Get(id);
            Discipline discipline = _context.Disciplines.Where(x => x.Id == disciplineId && x.InstitutionId == id).FirstOrDefault() ?? throw new BadRequestException($"Course/Discipline connection was not found with DisciplineId {id} and DisciplineId {disciplineId}");

            institution.Disciplines.Remove(discipline);
            _context.SaveChanges();
        }
    }
}
