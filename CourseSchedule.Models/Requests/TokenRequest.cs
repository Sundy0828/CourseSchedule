using System.ComponentModel.DataAnnotations;

namespace CourseSchedule.Models.Requests
{
    public class TokenRequest
    {
        [Required]
        public Guid PublicKey { get; set; }
        [Required]
        public Guid SecretKey { get; set; }
    }
}
