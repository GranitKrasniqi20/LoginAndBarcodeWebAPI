using LoginAndBarcodeWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAndBarcodeWebAPI
{
    public class DatabaseContext : DbContext    
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Barcode> Barcodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique constraint for the Username property of the User entity
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
