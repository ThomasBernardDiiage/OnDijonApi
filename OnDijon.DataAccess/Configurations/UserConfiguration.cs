using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDijon.Domain;

namespace OnDijon.DataAccess.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.Property(e => e.Id)
           .HasColumnName("Id")
           .ValueGeneratedOnAdd();

        builder.Property(e => e.Guid);

        builder.Property(e => e.Age);

        builder.HasOne<MeanOfLocomotion>()
            .WithMany()
            .HasForeignKey(e => e.MeanOfLocomotionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne<ReasonForTravel>()
            .WithMany()
            .HasForeignKey(e => e.ReasonForTravelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
