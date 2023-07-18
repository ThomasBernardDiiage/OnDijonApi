using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDijon.Domain;

namespace OnDijon.DataAccess.Configurations;

internal class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> builder)
    {
        builder.ToTable(nameof(Shelter));

        builder.Property(e => e.Id)
           .HasColumnName("Id")
           .ValueGeneratedOnAdd();

        builder.Property(e => e.Name);

        builder.Property(e => e.Latitude);

        builder.Property(e => e.Longitude);

        builder.Property(e => e.Capacity);
    }
}