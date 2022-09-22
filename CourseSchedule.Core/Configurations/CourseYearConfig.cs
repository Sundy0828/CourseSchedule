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
    public class CourseYearConfig : IEntityTypeConfiguration<CourseYear>
    {
        public void Configure(EntityTypeBuilder<CourseYear> builder)
        {
            builder.ToTable("CourseYears");

            builder.HasKey(cy => new { cy.CourseId, cy.YearId });

            builder
                .HasOne<Course>(cy => cy.Course)
                .WithMany(c => c.CourseYears)
                .HasForeignKey(cy => cy.CourseId);

            builder
                .HasOne<Year>(cy => cy.Year)
                .WithMany(c => c.CourseYears)
                .HasForeignKey(cy => cy.YearId);
        }
    }
}
