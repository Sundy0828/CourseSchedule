using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class CourseDiscipline : CourseScheduleEntity
    {
        public CourseDiscipline(Guid courseId, Guid disciplineId)
        {
            CourseId = courseId;
            DisciplineId = disciplineId;
        }
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }
        public Guid DisciplineId { get; private set; }
        public Discipline Discipline { get; private set; }
    }
}
