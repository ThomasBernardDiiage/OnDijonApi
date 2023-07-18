using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDijon.Domain;

namespace OnDijon.DataAccess.Configurations;

internal class ShelterHistoryConfiguration : IEntityTypeConfiguration<ShelterHistory>
{
    public void Configure(EntityTypeBuilder<ShelterHistory> builder)
    {
        builder.ToTable(nameof(ShelterHistory));

        builder.Property(e => e.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Date);

        builder.Property(e => e.IsEntry);

        builder.Property(e => e.Spot);

        builder.HasOne<Shelter>()
            .WithMany()
            .HasForeignKey(e => e.ShelterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

