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
    public class CourseCombinationConfig : IEntityTypeConfiguration<CourseCombination>
    {
        public void Configure(EntityTypeBuilder<CourseCombination> builder)
        {
            builder.ToTable("CourseCombinations");

            builder.HasKey(cc => new { cc.CourseId, cc.CombinationId });

            builder
                .HasOne<Course>(cc => cc.Course)
                .WithMany(c => c.CourseCombinations)
                .HasForeignKey(cc => cc.CourseId);

            builder
                .HasOne<Combination>(cc => cc.Combination)
                .WithMany(c => c.CourseCombinations)
                .HasForeignKey(cc => cc.CombinationId);
        }
    }
}
