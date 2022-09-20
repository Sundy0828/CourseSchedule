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
        private readonly HashSet<Discipline> disciplines;
        private readonly HashSet<Combination> combinations; 
        private readonly HashSet<Semester> semesters;
        private readonly HashSet<Year> years;

        public Course(string name, int credits, string courseCode)
        {
            Id = Guid.NewGuid();
            Name = name;
            CourseCode = courseCode;
            Credits = credits;

            disciplines = new HashSet<Discipline>();
            combinations = new HashSet<Combination>();
            semesters = new HashSet<Semester>();
            years = new HashSet<Year>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Credits { get; private set; }
        public string CourseCode { get; private set; }

        // Navigation Properties
        public IReadOnlyCollection<Discipline> Disciplines => disciplines;
        public IReadOnlyCollection<Combination> Combinations => combinations;
        public IReadOnlyCollection<Semester> Semesters => semesters;
        public IReadOnlyCollection<Year> Years => years;

        public void Update(string name, int credits, string courseCode)
        {
            // logic to ensure the name is valid
            Name = name;
            CourseCode = courseCode;
            Credits = credits;
        }

        public void AddDiscipline(Discipline discipline)
        {
            // Some logic to handle whether a book
            // can be added or not
            disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            // Logic
            disciplines.Remove(discipline);
        }

        public void AddCombination(Combination combination)
        {
            // Some logic to handle whether a book
            // can be added or not
            combinations.Add(combination);
        }

        public void RemoveCombination(Combination combination)
        {
            // Logic
            combinations.Remove(combination);
        }

        public void AddSemester(Semester semester)
        {
            // Some logic to handle whether a book
            // can be added or not
            semesters.Add(semester);
        }

        public void RemoveSemester(Semester semester)
        {
            // Logic
            semesters.Remove(semester);
        }

        public void AddYear(Year year)
        {
            // Some logic to handle whether a book
            // can be added or not
            years.Add(year);
        }

        public void RemoveYear(Year year)
        {
            // Logic
            years.Remove(year);
        }
    }
}
