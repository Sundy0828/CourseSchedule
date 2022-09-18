using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSchedule.Core.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseSchedule.Core.Configurations
{
    public class DisciplineConfig : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable("Disciplines"); // Not required, but I like to explicitly state the table name

            builder.HasKey("Id") // Tell EF to find the field called "Id" and use it as primary key
                .HasName("PK_Disciplines"); // Primary key object name in the database (NOT column name)

            builder.Property(d => d.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            builder.Metadata
                .FindNavigation(nameof(Discipline.Courses))
                // Convention based -> will find field named "Courses"
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
