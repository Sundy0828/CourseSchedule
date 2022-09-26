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
    public class CourseLogic
    {
        private readonly ILogger<CourseLogic> _logger;
        private readonly CourseScheduleDBContext _context;
        private readonly DisciplineLogic _disciplineLogic;

        public CourseLogic(ILogger<CourseLogic> logger, CourseScheduleDBContext context, DisciplineLogic disciplineLogic)
        {
            _logger = logger;
            _context = context;
            _disciplineLogic = disciplineLogic;
        }

        public PagedList<Course> GetAll(Pagination pagination)
        {
            _logger.LogInformation("Get all Courses");

            return PagedList<Course>.ToPagedList(_context.Courses.OrderBy(c => c.Name),
                pagination.PageNumber,
                pagination.PageSize);
        }

        public Course Get(Guid id)
        {
            _logger.LogInformation("Get Course {ID}", id);

            return _context.Courses.Where(c => c.Id == id).FirstOrDefault() ?? throw new NotFoundException($"Course was not found with Id {id}");
        }

        public Course Create(CourseRequest c)
        {
            _logger.LogInformation("Create Course {Institusion}", c.Name);

            Course course = new()
            {
                Name = c.Name,
                Credits = c.Credits,
                CourseCode = c.CourseCode
            };

            _context.Add(course);
            _context.SaveChanges();

            return course;
        }

        public Course PutUpdate(Guid id, CourseRequest c)
        {
            _logger.LogInformation("Put Update {Institusion} {ID}", c.Name,  id);

            Course course = _context.Courses.Where(c => c.Id == id ).FirstOrDefault() ?? throw new NotFoundException($"Course was not found with Id {id}");

            course.Name = c.Name;
            course.Credits = c.Credits;
            course.CourseCode = c.CourseCode;

            _context.Update(course);
            _context.SaveChanges();

            return course;
        }

        public Course PatchUpdate( Guid id, CourseRequest c)
        {
            _logger.LogInformation("Patch Update {Institusion} {ID}", c.Name, id);

            Course course = _context.Courses.Where(c => c.Id == id).FirstOrDefault() ?? throw new NotFoundException($"Course was not found with Id {id}");

            course.Name = c.Name;
            course.Credits = c.Credits;
            course.CourseCode = c.CourseCode;

            _context.Update(course);
            _context.SaveChanges();

            return course;
        }

        public void Delete(Guid id)
        {
            _logger.LogInformation("Delete Course {ID}", id);

            Course course = _context.Courses.Where(c => c.Id == id).FirstOrDefault() ?? throw new NotFoundException($"Course was not found with Id {id}");

            _context.Remove(course);
            _context.SaveChanges();
        }
    }
}
