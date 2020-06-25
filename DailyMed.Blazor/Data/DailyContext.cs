using Microsoft.EntityFrameworkCore;
using DailyMed.Blazor.Models;

namespace DailyMed.Blazor.Data
{
    public class DailyContext : DbContext 
    {
        public DailyContext(DbContextOptions<DailyContext> options) : base(options)
        {
        }
        
        public DbSet<Datum> Data { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Datum>().HasKey(d => d.Code);
            base.OnModelCreating(builder);
        }
    }
}
