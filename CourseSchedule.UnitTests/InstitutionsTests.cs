using CourseSchedule.Models.Requests;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Shouldly;
using CourseSchedule.Models.Pagination;

namespace CourseSchedule.UnitTests
{
    public class InstitutionsTests : InMemoryDatabaseTest
    {
        private Institution i;

        public InstitutionsTests() : base()
        {
            i = _institutionLogic.Create(new InstitutionRequest()
            {
                Name = "Seton Hill University"
            });
        }

        [Fact]
        public void PostInstitution()
        {
            Institution insitution = _institutionLogic.Create(new InstitutionRequest()
            {
                Name = "Carnegie Mellon University"
            });

            insitution.ShouldNotBeNull();
            insitution.Name.ShouldBeEquivalentTo("Carnegie Mellon University");
        }

        [Fact]
        public void GetAllInstitutions()
        {
            InstitutionPagination pagination = new();
            List<Institution> insitutions = _institutionLogic.GetAll(pagination);

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
            Should.Throw<Exception>(() => _institutionLogic.Get(i.Id));
        }
    }
}
