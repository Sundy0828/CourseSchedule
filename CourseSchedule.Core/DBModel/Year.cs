using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Year : CourseScheduleEntity
    {
        public Year()
        {
            Id = Guid.NewGuid();
            Name = "";

            CourseYears = new HashSet<CourseYear>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }


        // Navigation Properties
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public ICollection<CourseYear> CourseYears { get; set; }
    }
}
