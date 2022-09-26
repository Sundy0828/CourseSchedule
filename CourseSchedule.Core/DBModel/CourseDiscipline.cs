using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseSchedule.Core.DBModel
{
    public class CourseDiscipline : CourseScheduleEntity
    {
        public CourseDiscipline()
        {

        }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
