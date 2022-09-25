using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Year : CourseScheduleEntity
    {
        private readonly HashSet<CourseYear> courses;

        public Year(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            courses = new HashSet<CourseYear>();
        }


        public Guid Id { get; private set; }
        public string Name { get; private set; }


        // Navigation Properties
        public Institution Institution { get; private set; }
        public IReadOnlyCollection<CourseYear> CourseYears => courses;

        public void Update(string name)
        {
            // logic to ensure the name is valid
            Name = name;
        }

        public void AddCourse(CourseYear course)
        {
            // Some logic to handle whether a book
            // can be added or not
            courses.Add(course);
        }

        public void RemoveCourse(CourseYear course)
        {
            // Logic
            courses.Remove(course);
        }
    }
}
