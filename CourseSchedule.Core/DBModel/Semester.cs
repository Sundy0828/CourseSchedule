using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Semester : CourseScheduleEntity
    {
        private readonly HashSet<Course> courses;

        public Semester(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            courses = new HashSet<Course>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }


        // Navigation Properties
        public Institution Institution { get; private set; }
        public IReadOnlyCollection<Course> Courses => courses;

        public void Update(string name)
        {
            // logic to ensure the name is valid
            Name = name;
        }

        public void AddCourse(Course course)
        {
            // Some logic to handle whether a book
            // can be added or not
            courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            // Logic
            courses.Remove(course);
        }
    }
}
