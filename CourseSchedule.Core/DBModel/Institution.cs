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
    [Table("institutions")]
    public class Institution : CourseScheduleEntity
    {
        private readonly HashSet<Discipline> disciplines;

        public Institution(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            PublicKey = Guid.NewGuid();
            SecretKey = Guid.NewGuid();

            disciplines = new HashSet<Discipline>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid PublicKey { get; private set; }
        public Guid SecretKey { get; private set; }

        // Navigation Properties
        public IReadOnlyCollection<Discipline> Disciplines => disciplines;

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
    }
}
