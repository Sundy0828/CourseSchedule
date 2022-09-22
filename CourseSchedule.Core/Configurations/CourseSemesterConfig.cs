using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSchedule.Core.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseSchedule.Core.Configurations
{
    public class CourseSemesterConfig : IEntityTypeConfiguration<CourseSemester>
    {
        public void Configure(EntityTypeBuilder<CourseSemester> builder)
        {
            builder.ToTable("CourseSemesters");

            builder.HasKey(cs => new { cs.CourseId, cs.SemesterId });

            builder
                .HasOne<Course>(cs => cs.Course)
                .WithMany(c => c.CourseSemesters)
                .HasForeignKey(cs => cs.CourseId);

            builder
                .HasOne<Semester>(cs => cs.Semester)
                .WithMany(c => c.CourseSemesters)
                .HasForeignKey(cs => cs.SemesterId);
        }
    }
}
