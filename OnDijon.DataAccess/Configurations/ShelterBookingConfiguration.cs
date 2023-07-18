using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDijon.Domain;

namespace OnDijon.DataAccess.Configurations;

internal class ShelterBookingConfiguration : IEntityTypeConfiguration<ShelterBooking>
{
    public void Configure(EntityTypeBuilder<ShelterBooking> builder)
    {
        builder.ToTable(nameof(ShelterBooking));

        builder.Property(e => e.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Date);
        builder.Property(e => e.BeginDate);
        builder.Property(e => e.EndDate);


        builder.HasOne<Shelter>()
            .WithMany()
            .HasForeignKey(e => e.ShelterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}