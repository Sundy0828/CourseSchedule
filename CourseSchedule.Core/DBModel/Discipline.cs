using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Discipline : CourseScheduleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MajorCode { get; set; }
        public bool IsMajor { get; set; }

        // Navigation Properties
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public ICollection<CourseDiscipline> CourseDisciplines { get; set; }
    }
}
