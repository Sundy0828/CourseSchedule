﻿namespace CourseSchedule.Models.Response
{
    public class DisciplineResponse : ResponseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsMajor { get; set; }
    }
}
