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
    public class YearConfig : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> builder)
        {
            builder.ToTable("Years"); // Not required, but I like to explicitly state the table name

            builder.HasKey("Id") // Tell EF to find the field called "Id" and use it as primary key
                .HasName("PK_Years"); // Primary key object name in the database (NOT column name)

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
