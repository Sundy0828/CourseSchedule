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
        public Institution()
        {
            Id = Guid.NewGuid();
            Name = "";
            PublicKey = Guid.NewGuid();
            SecretKey = Guid.NewGuid();

            Disciplines = new HashSet<Discipline>();
            Semesters = new HashSet<Semester>();
            Years = new HashSet<Year>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PublicKey { get; set; }
        public Guid SecretKey { get; set; }

        // Navigation Properties
        public ICollection<Discipline> Disciplines { get; set; }
        public ICollection<Semester> Semesters { get; set; }
        public ICollection<Year> Years { get; set; }

    }
}
