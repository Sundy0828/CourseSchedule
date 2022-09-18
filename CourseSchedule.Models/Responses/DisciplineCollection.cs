
namespace CourseSchedule.API.Models.Response
{
    public class DisciplineCollection : ResponseCollection<DisciplineResponse>
    {
        public DisciplineCollection(List<DisciplineResponse> disciplines)
        {
            Data = disciplines;
        }
    }
}
