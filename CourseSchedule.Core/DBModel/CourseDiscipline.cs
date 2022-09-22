using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class CourseDiscipline
    {

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
