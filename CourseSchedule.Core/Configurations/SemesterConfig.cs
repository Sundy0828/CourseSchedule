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
            builder.ToTable("Semesters");

            builder.HasKey("Id").HasName("PK_Semesters");

            builder.Property(s => s.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            builder
                .HasOne<Institution>(i => i.Institution)
                .WithMany(s => s.Semesters)
                .HasForeignKey(s => s.InstitutionId);
        }
    }
}
