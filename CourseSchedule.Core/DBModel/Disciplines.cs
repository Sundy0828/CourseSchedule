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
    public class Disciplines : CourseScheduleEntity
    {
        public Disciplines()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("is_major")]
        public bool IsMajor { get; set; }
    }
}
