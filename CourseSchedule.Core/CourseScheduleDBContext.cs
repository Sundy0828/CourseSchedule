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
            // Combination
            builder.Entity<Combination>()
                .ToTable("Combinations");

            builder.Entity<Combination>()
                .HasKey(x => x.Id).HasName("PK_Combinations");

            // Course
            builder.Entity<Course>()
                .ToTable("Courses");

            builder.Entity<Course>()
                .HasKey(x => x.Id).HasName("PK_Courses");

            builder.Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            // Discipline
            builder.Entity<Discipline>()
                .ToTable("Disciplines");

            builder.Entity<Discipline>()
                .HasKey(x => x.Id).HasName("PK_Disciplines");

            builder.Entity<Discipline>()
                .Property(d => d.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            builder.Entity<Discipline>()
                .HasOne(i => i.Institution)
                .WithMany(d => d.Disciplines)
                .HasForeignKey(d => d.InstitutionId);

            // Institution
            builder.Entity<Institution>()
                .ToTable("Institutions");

            builder.Entity<Institution>()
                .HasKey(x => x.Id).HasName("PK_Institutions");

            builder.Entity<Institution>()
                .Property(i => i.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            // Semester
            builder.Entity<Semester>()
                .ToTable("Semesters");

            builder.Entity<Semester>()
                .HasKey(x => x.Id).HasName("PK_Semesters");

            builder.Entity<Semester>()
                .Property(s => s.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            builder.Entity<Semester>()
                .HasOne(i => i.Institution)
                .WithMany(s => s.Semesters)
                .HasForeignKey(s => s.InstitutionId);

            // Year
            builder.Entity<Year>()
                .ToTable("Years");

            builder.Entity<Year>()
                .HasKey(x => x.Id).HasName("PK_Years");

            builder.Entity<Year>()
                .Property(y => y.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            builder.Entity<Year>()
                .HasOne(i => i.Institution)
                .WithMany(y => y.Years)
                .HasForeignKey(y => y.InstitutionId);

            // CourseCombination
            builder.Entity<CourseCombination>()
                .ToTable("CourseCombinations");

            builder.Entity<CourseCombination>()
                .HasKey(t => new { t.CourseId, t.CombinationId }).HasName("PK_CourseCombinations");

            builder.Entity<CourseCombination>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseCombinations)
                .HasForeignKey(pt => pt.CourseId);

            builder.Entity<CourseCombination>()
                .HasOne(pt => pt.Combination)
                .WithMany(t => t.CourseCombinations)
                .HasForeignKey(pt => pt.CombinationId);

            // CourseDiscipline
            builder.Entity<CourseDiscipline>()
                .ToTable("CourseDisciplines");

            builder.Entity<CourseDiscipline>()
                .HasKey(t => new { t.CourseId, t.DisciplineId }).HasName("PK_CourseDisciplines");

            builder.Entity<CourseDiscipline>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseDisciplines)
                .HasForeignKey(pt => pt.CourseId);

            builder.Entity<CourseDiscipline>()
                .HasOne(pt => pt.Discipline)
                .WithMany(t => t.CourseDisciplines)
                .HasForeignKey(pt => pt.DisciplineId);

            // CourseCombination
            builder.Entity<CourseSemester>()
                .ToTable("CourseSemesters");

            builder.Entity<CourseSemester>()
                .HasKey(t => new { t.CourseId, t.SemesterId }).HasName("PK_CourseSemesters");

            builder.Entity<CourseSemester>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseSemesters)
                .HasForeignKey(pt => pt.CourseId);

            builder.Entity<CourseSemester>()
                .HasOne(pt => pt.Semester)
                .WithMany(t => t.CourseSemesters)
                .HasForeignKey(pt => pt.SemesterId);

            // CourseCombination
            builder.Entity<CourseYear>()
                .ToTable("CourseYears");

            builder.Entity<CourseYear>()
                .HasKey(t => new { t.CourseId, t.YearId }).HasName("PK_CourseYears");

            builder.Entity<CourseYear>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseYears)
                .HasForeignKey(pt => pt.CourseId);

            builder.Entity<CourseYear>()
                .HasOne(pt => pt.Year)
                .WithMany(t => t.CourseYears)
                .HasForeignKey(pt => pt.YearId);
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

        // Main Tables
        public virtual DbSet<Combination> Combination { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<CourseCombination> CourseCombinations { get; set; }
        public virtual DbSet<CourseDiscipline> CourseDisciplines { get; set; }
        public virtual DbSet<CourseSemester> CourseSemesters { get; set; }
        public virtual DbSet<CourseYear> CourseYears { get; set; }
    }
}
