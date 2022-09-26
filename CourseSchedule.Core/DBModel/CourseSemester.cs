﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseSchedule.Core.DBModel
{
    public class CourseSemester : CourseScheduleEntity
    {
        public CourseSemester()
        {

        }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid SemesterId { get; set; }
        public Semester Semester { get; set; }
    }
}
