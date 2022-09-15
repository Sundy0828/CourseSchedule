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
    public class Institutions : CourseScheduleEntity
    {
        public Institutions()
        {
            Id = Guid.NewGuid();
            PublicKey = Guid.NewGuid();
            SecretKey = Guid.NewGuid();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("public_key")]
        public Guid PublicKey { get; set; }
        [Column("secret_key")]
        public Guid SecretKey { get; set; }
    }
}
