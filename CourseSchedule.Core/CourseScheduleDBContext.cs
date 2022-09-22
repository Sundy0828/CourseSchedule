using Microsoft.EntityFrameworkCore;
using CourseSchedule.Core.DBModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            IEnumerable<EntityEntry> entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is CourseScheduleEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (EntityEntry entry in entries)
            {
                ((CourseScheduleEntity)entry.Entity).Modified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    ((CourseScheduleEntity)entry.Entity).Created = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
    }
}
