using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Semester : CourseScheduleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        // Navigation Properties
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public ICollection<CourseSemester> CourseSemesters { get; set; }
    }
}
