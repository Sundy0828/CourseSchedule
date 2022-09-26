using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseSchedule.Core.DBModel
{
    public class CourseCombination : CourseScheduleEntity
    {
        public CourseCombination()
        {
            
        }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid CombinationId { get; set; }
        public Combination Combination { get; set; }
        public Guid? SubCombinationId { get; set; }
    }
}
