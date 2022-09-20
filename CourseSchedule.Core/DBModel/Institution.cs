using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace CourseSchedule.Core.DBModel
{
    public class Institution : CourseScheduleEntity
    {
        private readonly HashSet<Discipline> disciplines;
        private readonly HashSet<Semester> semesters;
        private readonly HashSet<Year> years;

        public Institution(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            PublicKey = Guid.NewGuid();
            SecretKey = Guid.NewGuid();

            disciplines = new HashSet<Discipline>();
            semesters = new HashSet<Semester>();
            years = new HashSet<Year>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid PublicKey { get; private set; }
        public Guid SecretKey { get; private set; }

        // Navigation Properties
        public IReadOnlyCollection<Discipline> Disciplines => disciplines;
        public IReadOnlyCollection<Semester> Semesters => semesters;
        public IReadOnlyCollection<Year> Years => years;

        public void Update(string name)
        {
            // logic to ensure the name is valid
            Name = name;
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
