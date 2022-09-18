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
            Id = Guid.NewGuid().ToString("D");
            Name = name;
            PublicKey = Guid.NewGuid().ToString("D");
            SecretKey = Guid.NewGuid().ToString("D");

            disciplines = new HashSet<Discipline>();
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string PublicKey { get; private set; }
        public string SecretKey { get; private set; }

        // Navigation Properties
        public IReadOnlyCollection<Discipline> Disciplines => disciplines;

        public void UpdateName(string name)
        {
            // logic to ensure the name is valid
            Name = name;
        }

        public void AddBook(Discipline discipline)
        {
            // Some logic to handle whether a book
            // can be added or not
            disciplines.Add(discipline);
        }

        public void RemoveBook(Discipline discipline)
        {
            // Logic
            disciplines.Remove(discipline);
        }
    }
}
