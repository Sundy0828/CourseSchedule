namespace CourseSchedule.API
{
    public class AppSettings
    {
        public class ConnectionStringConfig
        {
            public string DefaultConnection { get; set; }
        }

        public ConnectionStringConfig ConnectionStrings { get; set; }
    }
}
