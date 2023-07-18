using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDijon.Domain;

namespace OnDijon.DataAccess.Configurations;

internal class ReasonForTravelConfiguration : IEntityTypeConfiguration<ReasonForTravel>
{
    public void Configure(EntityTypeBuilder<ReasonForTravel> builder)
    {
        builder.ToTable(nameof(ReasonForTravel));

        builder.Property(e => e.Id)
           .HasColumnName("Id")
           .ValueGeneratedOnAdd();

        builder.Property(e => e.Label);
    }
}
