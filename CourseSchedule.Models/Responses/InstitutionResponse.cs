namespace CourseSchedule.Models.Response
{
    public class InstitutionResponse : ResponseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid PublicKey { get; private set; }
        public Guid SecretKey { get; private set; }
    }
}
