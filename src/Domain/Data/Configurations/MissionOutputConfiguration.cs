using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    public class MissionOutputConfiguration : IEntityTypeConfiguration<MissionOutput>
    {
        public void Configure(EntityTypeBuilder<MissionOutput> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Input).WithOne(b => b.Output).HasForeignKey<MissionInput>(b => b.OutputId);
        }
    }
}
