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
            builder.ToTable("Disciplines");

            builder.HasKey(x => x.Id).HasName("PK_Disciplines");

            builder.Property(d => d.Name)
                .HasMaxLength(250) // setting max length can provide huge performance gains
                .IsRequired();

            builder
                .HasOne(i => i.Institution)
                .WithMany(d => d.Disciplines)
                .HasForeignKey(d => d.Institution.Id);

            builder
                .HasMany(c => c.CourseDisciplines)
                .WithOne()
                .HasForeignKey(c => c.DisciplineId);
        }
    }
}
