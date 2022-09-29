using CourseSchedule.Models.Requests;
using CourseSchedule.Core;
using CourseSchedule.Core.DBModel;
using Shouldly;
using CourseSchedule.Models.Pagination;

namespace CourseSchedule.UnitTests
{
    public class DisciplinesTests : InMemoryDatabaseTest
    {
        private Discipline d;

        //public DisciplinesTests() : base()
        //{
        //    d = _disciplineLogic.Create(new DisciplineRequest()
        //    {
        //        Name = "Seton Hill University"
        //    });
        //}

        //[Fact]
        //public void PostDiscipline()
        //{
        //    Discipline insitution = _disciplineLogic.Create(new DisciplineRequest()
        //    {
        //        Name = "Carnegie Mellon University"
        //    });

        //    insitution.ShouldNotBeNull();
        //    insitution.Name.ShouldBeEquivalentTo("Carnegie Mellon University");
        //}

        //[Fact]
        //public void GetAllDisciplines()
        //{
        //    DisciplinePagination pagination = new();
        //    List<Discipline> insitutions = _disciplineLogic.GetAll(pagination);

        //    insitutions.ShouldNotBeNull();
        //}

        //[Fact]
        //public void GetDiscipline()
        //{
        //    Discipline insitution = _disciplineLogic.Get(d.Id);

        //    insitution.ShouldNotBeNull();
        //}

        //[Fact]
        //public void PutDiscipline()
        //{
        //    DisciplineRequest request = new()
        //    {
        //        Name = "Seton Hall University"
        //    };
        //    Discipline insitution = _disciplineLogic.PutUpdate(d.Id, request);

        //    insitution.ShouldNotBeNull();
        //}

        //[Fact]
        //public void PatchDiscipline()
        //{
        //    DisciplineRequest request = new()
        //    {
        //        Name = "Seton Hall University"
        //    };
        //    Discipline insitution = _disciplineLogic.PatchUpdate(d.Id, request);

        //    insitution.ShouldNotBeNull();
        //}

        //[Fact]
        //public void DeleteDiscipline()
        //{
        //    _disciplineLogic.Delete(d.Id);
        //    Should.Throw<Exception>(() => _disciplineLogic.Get(d.Id));
        //}
    }
}
