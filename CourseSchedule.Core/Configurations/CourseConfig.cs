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
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses"); // Not required, but I like to explicitly state the table name

            builder.HasKey("Id") // Tell EF to find the field called "Id" and use it as primary key
                .HasName("PK_Courses"); // Primary key object name in the database (NOT column name)

            builder.Property(i => i.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            // Tell EF to find the navigation property and use this for the Disciplines collection
            builder.Metadata
                .FindNavigation(nameof(Course.Disciplines))
                // Convention based -> will find field named "Disciplines"
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata
                .FindNavigation(nameof(Course.Semesters))
                // Convention based -> will find field named "Semesters"
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata
                .FindNavigation(nameof(Course.Years))
                // Convention based -> will find field named "Years"
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
