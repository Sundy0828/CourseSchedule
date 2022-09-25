using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class CourseYear : CourseScheduleEntity
    {
        public CourseYear(Guid courseId, Guid yearId)
        {
            CourseId = courseId;
            YearId = yearId;
        }
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }
        public Guid YearId { get; private set; }
        public Year Year { get; private set; }
    }
}
