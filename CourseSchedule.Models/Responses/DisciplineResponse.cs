namespace CourseSchedule.API.Models.Response
{
    public class DisciplineResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsMajor { get; private set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
