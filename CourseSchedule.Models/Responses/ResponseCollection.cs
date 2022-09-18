namespace CourseSchedule.API.Models.Response
{
    public class ResponseCollection<T>
    {
        public int Total
        {
            get
            {
                if (Data == null)
                {
                    return 0;
                }

                return Data.Count;
            }
        }

        public List<T> Data { get; set; }
    }
}
