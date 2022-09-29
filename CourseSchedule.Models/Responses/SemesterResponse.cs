namespace CourseSchedule.Models.Response
{
    public class SemesterResponse : ResponseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
