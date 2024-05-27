using Adres.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adres.API.Data.Configurations
{
    public class AcquisitionRequirementConfiguration : IEntityTypeConfiguration<AcquisitionRequirement>
    {
        public void Configure(EntityTypeBuilder<AcquisitionRequirement> builder)
        {
            builder.ToTable("AcquisitionRequirement");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
        }
    }
}