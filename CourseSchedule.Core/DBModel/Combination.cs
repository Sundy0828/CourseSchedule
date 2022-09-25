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
        private readonly HashSet<CourseCombination> courses;
        public Combination(LogicalOperator logicalOperator)
        {
            Id = Guid.NewGuid();
            LogicalOperator = logicalOperator;

            courses = new HashSet<CourseCombination>();
        }

        public Guid Id { get; private set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LogicalOperator LogicalOperator { get; private set; }

        // Navigation Properties
        public IReadOnlyCollection<CourseCombination> CourseCombinations => courses;


        public void Update(LogicalOperator logicalOperator)
        {
            // logic to ensure the name is valid
            LogicalOperator = logicalOperator;
        }

        public void AddCourse(CourseCombination course)
        {
            // Some logic to handle whether a book
            // can be added or not
            courses.Add(course);
        }

        public void RemoveCourse(CourseCombination course)
        {
            // Logic
            courses.Remove(course);
        }
    }
}
