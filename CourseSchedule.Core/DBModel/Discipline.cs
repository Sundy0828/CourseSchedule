using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    [Table("disciplines")]
    public class Discipline : CourseScheduleEntity
    {
        public Discipline(string name, bool isMajor)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsMajor = isMajor;

        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsMajor { get; private set; }

        // Navigation Properties
        public Guid InstitutionId { get; private set; }
        public Institution Institution { get; private set; }


        public void Update(string name, bool isMajor)
        {
            // logic to ensure the name is valid
            Name = name;
            IsMajor = isMajor;
        }
    }
}
