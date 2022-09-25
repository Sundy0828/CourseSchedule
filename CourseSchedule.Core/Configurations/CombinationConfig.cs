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
            builder.ToTable("Combinations");

            builder.HasKey(x => x.Id).HasName("PK_Combinations");

            builder
                .HasMany(c => c.CourseCombinations)
                .WithOne()
                .HasForeignKey(c => c.CombinationId);
        }
    }
}
