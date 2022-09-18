using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public enum LogicalOperator
    {
        OR,
        AND
    }
    public class Combination : CourseScheduleEntity
    {
        private readonly HashSet<Course> courses;
        public Combination(Guid courseId, LogicalOperator logicalOperator)
        {
            Id = Guid.NewGuid();
            LogicalOperator = logicalOperator;

            CourseId = courseId;
        }

        public Guid Id { get; private set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LogicalOperator LogicalOperator { get; private set; }

        // Navigation Properties
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }
        public IReadOnlyCollection<Course> Courses => courses;


        public void Update(Guid courseId, LogicalOperator logicalOperator)
        {
            // logic to ensure the name is valid
            CourseId = courseId;
            LogicalOperator = logicalOperator;
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
