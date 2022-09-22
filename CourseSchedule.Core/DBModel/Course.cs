using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class Course : CourseScheduleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string CourseCode { get; set; }

        // Navigation Properties
        public ICollection<CourseDiscipline> CourseDisciplines { get; set; }
        public ICollection<CourseCombination> CourseCombinations { get; set; }
        public ICollection<CourseSemester> CourseSemesters { get; set; }
        public ICollection<CourseYear> CourseYears { get; set; }
    }
}
