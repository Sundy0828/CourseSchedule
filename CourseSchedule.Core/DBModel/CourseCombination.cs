using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class CourseCombination
    {

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid CombinationId { get; set; }
        public Combination Combination { get; set; }
        public Guid SubCombinationId { get; set; }
    }
}
