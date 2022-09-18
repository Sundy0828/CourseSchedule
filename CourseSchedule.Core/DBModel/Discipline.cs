﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    [Table("disciplines")]
    public class Discipline : CourseScheduleEntity
    {
        private readonly HashSet<Course> courses;
        public Discipline(Guid institutionId, string name, string majorCode, bool isMajor)
        {
            Id = Guid.NewGuid();
            Name = name;
            MajorCode = majorCode;
            IsMajor = isMajor;

            InstitutionId = institutionId;

            courses = new HashSet<Course>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string MajorCode { get; private set; }
        public bool IsMajor { get; private set; }

        // Navigation Properties
        public Guid InstitutionId { get; private set; }
        public Institution Institution { get; private set; }
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }
        public IReadOnlyCollection<Course> Courses => courses;


        public void Update(Guid institutionId, string name, string majorCode, bool isMajor)
        {
            // logic to ensure the name is valid
            InstitutionId = institutionId;
            Name = name;
            MajorCode = majorCode;
            IsMajor = isMajor;
        }

        public void AddCourse(Course course)
        {
            // Some logic to handle whether a book
            // can be added or not
            courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            // Logic
            courses.Remove(course);
        }
    }
}
