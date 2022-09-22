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
    public class YearConfig : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> builder)
        {
            builder.ToTable("Years");

            builder.HasKey("Id").HasName("PK_Years");

            builder.Property(y => y.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            builder
                .HasOne<Institution>(i => i.Institution)
                .WithMany(y => y.Years)
                .HasForeignKey(y => y.InstitutionId);
        }
    }
}
