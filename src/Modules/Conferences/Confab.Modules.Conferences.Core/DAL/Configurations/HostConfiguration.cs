using Confab.Modules.Conferences.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Conferences.Core.DAL.Configurations;

public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}