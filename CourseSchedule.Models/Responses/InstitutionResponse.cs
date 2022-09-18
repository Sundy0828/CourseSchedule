namespace CourseSchedule.API.Models.Response
{
    public class InstitutionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PublicKey { get; set; }
        public Guid SecretKey { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
