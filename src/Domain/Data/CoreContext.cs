using Domain.Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Contexts
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
            
        }

        public DbSet<MissionInput> MissionInputs { get; set; }
        public DbSet<MissionOutput> MissionOutputs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MissionInputConfiguration());
            modelBuilder.ApplyConfiguration(new MissionOutputConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
