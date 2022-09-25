namespace CourseSchedule.Models.Response
{
    public class CourseResponse : ResponseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Credits { get; private set; }
        public string CourseCode { get; private set; }
    }
}
