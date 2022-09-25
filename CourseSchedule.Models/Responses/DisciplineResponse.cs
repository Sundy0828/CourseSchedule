namespace CourseSchedule.Models.Response
{
    public class DisciplineResponse : ResponseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsMajor { get; private set; }
    }
}
