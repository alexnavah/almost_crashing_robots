using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    public class MissionInputConfiguration : IEntityTypeConfiguration<MissionInput>
    {
        public void Configure(EntityTypeBuilder<MissionInput> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Output).WithOne(b => b.Input).HasForeignKey<MissionOutput>(b => b.InputId );
        }
    }
}
