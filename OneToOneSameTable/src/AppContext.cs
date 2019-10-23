using Microsoft.EntityFrameworkCore;

namespace OneToOneSameTable
{
    public class AppContext : DbContext
    {
        public AppContext() { }
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>()
            //    .HasOne(_ => _.Parent)
            //    .WithMany(_ => _.Children)
            //    .HasForeignKey(_ => _.CategoryId);
        }
    }
}
