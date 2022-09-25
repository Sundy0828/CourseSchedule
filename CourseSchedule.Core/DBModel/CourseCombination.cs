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
        public CourseCombination(Guid courseId, Guid combinationId)
        {
            CourseId = courseId;
            CombinationId = combinationId;
        }
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }
        public Guid CombinationId { get; private set; }
        public Combination Combination { get; private set; }
        public Guid SubCombinationId { get; private set; }
    }
}
