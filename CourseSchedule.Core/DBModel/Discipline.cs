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
        public Discipline()
        {
            this.DisciplineId = Guid.NewGuid();
            this.Institutions = new HashSet<Institution>();
        }

        [Key]
        [Required]
        [Column("id")]
        public Guid DisciplineId { get; set; }
        [Required]
        [ForeignKey("Institution")]
        [Column("institution_id")]
        public Guid InstitutionId { get; set; }
        [Required]
        [Column("name")]
        [MaxLength(256), MinLength(1)]
        public string Name { get; set; }
        [Required]
        [Column("is_major")]
        public bool IsMajor { get; set; }

        public virtual ICollection<Institution> Institutions { get; set; }
    }
}
