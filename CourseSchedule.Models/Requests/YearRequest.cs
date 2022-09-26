﻿using System.ComponentModel.DataAnnotations;

namespace CourseSchedule.Models.Requests
{
    public class YearRequest
    {
        [Required]

        [StringLength(maximumLength: 256, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
