using System.ComponentModel.DataAnnotations;

namespace CourseSchedule.API.Models.Creation
{
    public class DisciplineRequest
    {
        [Required]

        [StringLength(maximumLength: 256, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public string MajorCode { get; set; }
        [Required]
        public bool IsMajor { get; set; }
    }
}
