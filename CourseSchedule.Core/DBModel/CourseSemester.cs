using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class CourseSemester : CourseScheduleEntity
    {
        public CourseSemester(Guid courseId, Guid semesterId)
        {
            CourseId = courseId;
            SemesterId = semesterId;
        }
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }
        public Guid SemesterId { get; private set; }
        public Semester Semester { get; private set; }
    }
}
