using Confab.Modules.Speakers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Speakers.Core.DAL.Configurations;

internal class SpeakersConfiguration : IEntityTypeConfiguration<Speaker>
{
    public void Configure(EntityTypeBuilder<Speaker> builder)
    {
        builder.HasKey(speaker => speaker.Id);
        builder.Property(speaker => speaker.Email)
            .HasMaxLength(256)
            .IsRequired();
        builder.Property(speaker => speaker.FullName)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(speaker => speaker.Bio)
            .HasMaxLength(1500)
            .IsRequired(false);
    }
}