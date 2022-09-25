using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSchedule.Core.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CourseSchedule.Core.Configurations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(x => x.Id).HasName("PK_Courses");

            builder.Property(c => c.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            builder
                .HasMany(c => c.Combinations)
                .WithOne()
                .HasForeignKey(c => c.CourseId);
            builder
                .HasMany(c => c.Disciplines)
                .WithOne()
                .HasForeignKey(c => c.CourseId);
            builder
                .HasMany(c => c.Semesters)
                .WithOne()
                .HasForeignKey(c => c.CourseId);
            builder
                .HasMany(c => c.Disciplines)
                .WithOne()
                .HasForeignKey(c => c.CourseId);
        }
    }
}
