using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    [Table("institutions")]
    public class Institution : CourseScheduleEntity
    {
        public Institution()
        {
            this.InstitutionId = Guid.NewGuid();
            this.PublicKey = Guid.NewGuid();
            this.SecretKey = Guid.NewGuid();
        }

        [Key]
        [Required]
        [Column("id")]
        public Guid InstitutionId { get; set; }
        [Required]
        [Column("name")]
        [Index(IsUnique = true)]
        [MaxLength(256), MinLength(1)]
        public string Name { get; set; }
        [Required]
        [Column("public_key")]
        public Guid PublicKey { get; set; }
        [Required]
        [Column("secret_key")]
        public Guid SecretKey { get; set; }

        public virtual Discipline Discipline { get; set; }
    }
}
