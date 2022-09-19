using CourseSchedule.API.Models.Creation;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Shouldly;

namespace CourseSchedule.UnitTests
{
    public class InstitutionsTests : InMemoryDatabaseTest
    {
        readonly InstitutionLogic _logic;
        readonly CourseScheduleDBContext _context;

        private Institution i;
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        public InstitutionsTests() : base()
        {
            _context = new CourseScheduleDBContext(ContextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.SaveChanges();


        }

        [Fact]
        public void PostInstitution()
        {
            Institution insitution = _logic.Create(new InstitutionRequest()
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
            List<Institution> insitutions = _logic.GetAll();

            insitutions.ShouldNotBeNull();
        }

        [Fact]
        public void GetInstitution()
        {
            Institution insitution = _logic.Get(i.Id);

            insitution.ShouldNotBeNull();
        }

        [Fact]
        public void PutInstitution()
        {
            InstitutionRequest request = new()
            {
                Name = "Seton Hall University"
            };
            Institution insitution = _logic.PutUpdate(i.Id, request);

            insitution.ShouldNotBeNull();
        }

        [Fact]
        public void PatchInstitution()
        {
            InstitutionRequest request = new()
            {
                Name = "Seton Hall University"
            };
            Institution insitution = _logic.PatchUpdate(i.Id, request);

            insitution.ShouldNotBeNull();
        }

        [Fact]
        public void DeleteInstitution()
        {
            _logic.Delete(i.Id);
            Institution insitution = _logic.Get(i.Id);

            insitution.ShouldNotBeNull();
        }
    }
}
