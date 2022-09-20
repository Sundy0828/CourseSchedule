using System.Data.Common;
using CourseSchedule.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;

namespace CourseSchedule.UnitTests
{
    public class InMemoryDatabaseTest : IDisposable
    {
        protected readonly InstitutionLogic _institutionLogic;
        protected readonly CourseScheduleDBContext _context;

        private readonly DbConnection _connection;

        public InMemoryDatabaseTest()
        {
            DbContextOptions<CourseScheduleDBContext> contextOptions = new DbContextOptionsBuilder<CourseScheduleDBContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options;
            ContextOptions = contextOptions;

            _connection = RelationalOptionsExtension.Extract(contextOptions).Connection;

            _context = new CourseScheduleDBContext(ContextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.SaveChanges();

            _institutionLogic = new InstitutionLogic(Mock.Of<ILogger<InstitutionLogic>>(), _context);
        }

        protected DbContextOptions<CourseScheduleDBContext> ContextOptions { get; }

        private static DbConnection CreateInMemoryDatabase()
        {
            SqliteConnection? connection = new("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing) {  _connection.Dispose(); }
    }
}
