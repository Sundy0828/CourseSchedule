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
    public class SemesterConfig : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.ToTable("Semesters"); // Not required, but I like to explicitly state the table name

            builder.HasKey("Id") // Tell EF to find the field called "Id" and use it as primary key
                .HasName("PK_Semesters"); // Primary key object name in the database (NOT column name)

            builder.Property(i => i.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            // Tell EF to find the navigation property
            builder.Metadata
                .FindNavigation(nameof(Semester.Courses))
                // Convention based -> will find field named "Courses"
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata
                .FindNavigation(nameof(Semester.Institution))
                // Convention based -> will find field named "Institution"
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
