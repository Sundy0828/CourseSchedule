
namespace CourseSchedule.API.Models.Response
{
    public class InstitutionCollection : ResponseCollection<InstitutionResponse>
    {
        public InstitutionCollection(List<InstitutionResponse> institutions)
        {
            Data = institutions;
        }
    }
}
