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
    public class CombinationConfig : IEntityTypeConfiguration<Combination>
    {
        public void Configure(EntityTypeBuilder<Combination> builder)
        {
            builder.ToTable("Combinations"); // Not required, but I like to explicitly state the table name

            builder.HasKey("Id") // Tell EF to find the field called "Id" and use it as primary key
                .HasName("PK_Combinations"); // Primary key object name in the database (NOT column name)

            // Tell EF to find the navigation property and use this for the Disciplines collection
            builder.Metadata
                .FindNavigation(nameof(Combination.Courses))
                // Convention based -> will find field named "Courses"
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
