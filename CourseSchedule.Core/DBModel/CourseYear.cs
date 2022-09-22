using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class CourseYear
    {

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid YearId { get; set; }
        public Year Year { get; set; }
    }
}
