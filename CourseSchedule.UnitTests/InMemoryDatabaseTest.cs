using System.Data.Common;
using CourseSchedule.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CourseSchedule.UnitTests
{
    public class InMemoryDatabaseTest : IDisposable
    {
        private readonly DbConnection _connection;

        public InMemoryDatabaseTest()
        {
            DbContextOptions<CourseScheduleDBContext> contextOptions = new DbContextOptionsBuilder<CourseScheduleDBContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options;
            ContextOptions = contextOptions;

            _connection = RelationalOptionsExtension.Extract(contextOptions).Connection;
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
