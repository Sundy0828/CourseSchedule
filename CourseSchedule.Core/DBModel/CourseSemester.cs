﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public class CourseSemester
    {

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
    }
}
