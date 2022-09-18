using Microsoft.EntityFrameworkCore;
using CourseSchedule.Core.DBModel;

namespace CourseSchedule.Core
{
    public class CourseScheduleDBContext : DbContext
    {
        protected CourseScheduleDBContext()
        {

        }

        public CourseScheduleDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
    }
}
