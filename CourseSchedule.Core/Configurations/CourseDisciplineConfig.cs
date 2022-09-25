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
    public class CourseDisciplineConfig : IEntityTypeConfiguration<CourseDiscipline>
    {
        public void Configure(EntityTypeBuilder<CourseDiscipline> builder)
        {
            builder.ToTable("CourseDisciplines");

            builder.HasKey(cd => new { cd.CourseId, cd.DisciplineId });

            builder
                .HasOne<Course>(cd => cd.Course)
                .WithMany(c => c.Disciplines)
                .HasForeignKey(cd => cd.CourseId);

            builder
                .HasOne<Discipline>(cd => cd.Discipline)
                .WithMany(c => c.CourseDisciplines)
                .HasForeignKey(cd => cd.DisciplineId);
        }
    }
}
