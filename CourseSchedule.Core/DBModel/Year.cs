using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Year : CourseScheduleEntity
    {
        private readonly HashSet<Course> courses;

        public Year(Guid institutionId, string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            InstitutionId = institutionId;

            courses = new HashSet<Course>();
        }
        

        public Guid Id { get; private set; }
        public string Name { get; private set; }


        // Navigation Properties
        public Guid InstitutionId { get; private set; }
        public Institution Institution { get; private set; }
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }
        public IReadOnlyCollection<Course> Courses => courses;

        public void Update(Guid institutionId, string name)
        {
            // logic to ensure the name is valid
            InstitutionId = institutionId;
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
