namespace CourseSchedule.Models.Response
{
    public class InstitutionResponse : ResponseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PublicKey { get; set; }
        public Guid SecretKey { get; set; }
    }
}
