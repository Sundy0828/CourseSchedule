using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class CourseScheduleEntity
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
