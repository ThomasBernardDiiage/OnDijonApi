using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnDijon.Domain;

namespace OnDijon.DataAccess.Configurations;

internal class MeanOfLocomotionConfiguration : IEntityTypeConfiguration<MeanOfLocomotion>
{
    public void Configure(EntityTypeBuilder<MeanOfLocomotion> builder)
    {
        builder.ToTable(nameof(MeanOfLocomotion));

        builder.Property(e => e.Id)
           .HasColumnName("Id")
           .ValueGeneratedOnAdd();

        builder.Property(e => e.Label);
    }
}
