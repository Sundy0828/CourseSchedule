namespace CourseSchedule.Models.Response
{
    public class CourseResponse : ResponseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string CourseCode { get; set; }
    }
}
