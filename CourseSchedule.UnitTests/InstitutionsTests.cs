using CourseSchedule.API.Models.Requests;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Shouldly;

namespace CourseSchedule.UnitTests
{
    public class InstitutionsTests : InMemoryDatabaseTest
    {
        private Institution i;

        public InstitutionsTests() : base()
        {
            
        }

        [Fact]
        public void PostInstitution()
        {
            Institution insitution = _institutionLogic.Create(new InstitutionRequest()
            {
                Name = "Seton Hill University"
            });

            i = insitution;

            insitution.ShouldNotBeNull();
            insitution.Name.ShouldBeEquivalentTo("Seton Hill University");
        }

        [Fact]
        public void GetAllInstitutions()
        {
            List<Institution> insitutions = _institutionLogic.GetAll();

            insitutions.ShouldNotBeNull();
        }

        [Fact]
        public void GetInstitution()
        {
            Institution insitution = _institutionLogic.Get(i.Id);

            insitution.ShouldNotBeNull();
        }

        [Fact]
        public void PutInstitution()
        {
            InstitutionRequest request = new()
            {
                Name = "Seton Hall University"
            };
            Institution insitution = _institutionLogic.PutUpdate(i.Id, request);

            insitution.ShouldNotBeNull();
        }

        [Fact]
        public void PatchInstitution()
        {
            InstitutionRequest request = new()
            {
                Name = "Seton Hall University"
            };
            Institution insitution = _institutionLogic.PatchUpdate(i.Id, request);

            insitution.ShouldNotBeNull();
        }

        [Fact]
        public void DeleteInstitution()
        {
            _institutionLogic.Delete(i.Id);
            Institution insitution = _institutionLogic.Get(i.Id);

            insitution.ShouldNotBeNull();
        }
    }
}
