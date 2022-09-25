using System.ComponentModel.DataAnnotations;

namespace CourseSchedule.Models.Requests
{
    public class DisciplineRequest
    {
        [Required]

        [StringLength(maximumLength: 256, MinimumLength = 2)]
        public string Name { get; private set; }
        [Required]
        public string MajorCode { get; private set; }
        [Required]
        public bool IsMajor { get; private set; }
    }
}
