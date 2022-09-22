using System.ComponentModel.DataAnnotations;

namespace CourseSchedule.Models.Requests
{
    public class CourseRequest
    {
        [Required]

        [StringLength(maximumLength: 256, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [Range(0, 4, ErrorMessage = "Please enter valid amount of credits (0-4)")]
        public int Credits { get; set; }
        [Required]
        public string CourseCode { get; set; }
    }
}
