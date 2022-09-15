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
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is CourseScheduleEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((CourseScheduleEntity)entityEntry.Entity).Modified = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((CourseScheduleEntity)entityEntry.Entity).Created = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public virtual DbSet<Institutions> Institutions { get; set; }
        public virtual DbSet<Disciplines> Disciplines { get; set; }
    }
}
