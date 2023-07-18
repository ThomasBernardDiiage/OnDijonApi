using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDijon.Domain;

namespace OnDijon.DataAccess.Configurations;

internal class ShelterReportingConfiguration : IEntityTypeConfiguration<ShelterReporting>
{
    public void Configure(EntityTypeBuilder<ShelterReporting> builder)
    {
        builder.ToTable(nameof(ShelterReporting));

        builder.Property(e => e.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Object);
        builder.Property(e => e.Date);
        builder.Property(e => e.Comment);

        builder.HasOne<Shelter>()
            .WithMany()
            .HasForeignKey(e => e.ShelterId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}