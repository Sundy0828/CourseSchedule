using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Course : CourseScheduleEntity
    {
        private readonly HashSet<CourseDiscipline> disciplines;
        private readonly HashSet<CourseCombination> combinations;
        private readonly HashSet<CourseSemester> semesters;
        private readonly HashSet<CourseYear> years;

        public Course(string name, int credits, string courseCode)
        {
            Id = Guid.NewGuid();
            Name = name;
            CourseCode = courseCode;
            Credits = credits;

            disciplines = new HashSet<CourseDiscipline>();
            combinations = new HashSet<CourseCombination>();
            semesters = new HashSet<CourseSemester>();
            years = new HashSet<CourseYear>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Credits { get; private set; }
        public string CourseCode { get; private set; }

        // Navigation Properties
        public IReadOnlyCollection<CourseDiscipline> Disciplines => disciplines;
        public IReadOnlyCollection<CourseCombination> Combinations => combinations;
        public IReadOnlyCollection<CourseSemester> Semesters => semesters;
        public IReadOnlyCollection<CourseYear> Years => years;

        public void Update(string name, int credits, string courseCode)
        {
            // logic to ensure the name is valid
            Name = name;
            CourseCode = courseCode;
            Credits = credits;
        }

        public void AddDiscipline(CourseDiscipline discipline)
        {
            // Some logic to handle whether a book
            // can be added or not
            disciplines.Add(discipline);
        }

        public void RemoveDiscipline(CourseDiscipline discipline)
        {
            // Logic
            disciplines.Remove(discipline);
        }

        public void AddCombination(CourseCombination combination)
        {
            // Some logic to handle whether a book
            // can be added or not
            combinations.Add(combination);
        }

        public void RemoveCombination(CourseCombination combination)
        {
            // Logic
            combinations.Remove(combination);
        }

        public void AddSemester(CourseSemester semester)
        {
            // Some logic to handle whether a book
            // can be added or not
            semesters.Add(semester);
        }

        public void RemoveSemester(CourseSemester semester)
        {
            // Logic
            semesters.Remove(semester);
        }

        public void AddYear(CourseYear year)
        {
            // Some logic to handle whether a book
            // can be added or not
            years.Add(year);
        }

        public void RemoveYear(CourseYear year)
        {
            // Logic
            years.Remove(year);
        }
    }
}
