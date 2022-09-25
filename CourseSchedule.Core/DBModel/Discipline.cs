using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Discipline : CourseScheduleEntity
    {
        private readonly HashSet<CourseDiscipline> courses;
        public Discipline(string name, string majorCode, bool isMajor)
        {
            Id = Guid.NewGuid();
            Name = name;
            MajorCode = majorCode;
            IsMajor = isMajor;

            courses = new HashSet<CourseDiscipline>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string MajorCode { get; private set; }
        public bool IsMajor { get; private set; }

        // Navigation Properties
        public Institution Institution { get; private set; }
        public IReadOnlyCollection<CourseDiscipline> CourseDisciplines => courses;


        public void Update(string name, string majorCode, bool isMajor)
        {
            // logic to ensure the name is valid
            Name = name;
            MajorCode = majorCode;
            IsMajor = isMajor;
        }

        public void AddCourse(CourseDiscipline course)
        {
            // Some logic to handle whether a book
            // can be added or not
            courses.Add(course);
        }

        public void RemoveCourse(CourseDiscipline course)
        {
            // Logic
            courses.Remove(course);
        }
    }
}
