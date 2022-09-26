using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseSchedule.Core.DBModel
{
    public class CourseYear : CourseScheduleEntity
    {
        public CourseYear()
        {

        }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid YearId { get; set; }
        public Year Year { get; set; }
    }
}
