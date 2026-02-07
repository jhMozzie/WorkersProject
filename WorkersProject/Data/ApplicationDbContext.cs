using Microsoft.EntityFrameworkCore;
using WorkersProject.Model.Entity;

namespace WorkersProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
        public DbSet<Worker> Workers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Workers");
                entity.HasKey(e => e.Id);
                // Id attribute
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                // First attribute
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                // Last attribute
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
                // DocumentType attribute
                entity.Property(e => e.DocumentType).IsRequired().HasMaxLength(20).HasColumnType("nvarchar(20)");
                // DocumentNumber attribute
                entity.Property(e => e.DocumentNumber).IsRequired().HasMaxLength(20).HasColumnType("nvarchar(20)");
                // Gender attribute
                entity.Property(e => e.Gender).IsRequired().HasColumnType("nvarchar(1)");
                entity.ToTable(t => t.HasCheckConstraint("CK_Workers_Gender", "[Gender] IN ('M', 'F')"));
                // BirthDate attribute
                entity.Property(e => e.BirthDate).IsRequired().HasColumnType("date");
                // Photo attribute
                entity.Property(e => e.Photo).IsRequired(false).HasColumnType("nvarchar(max)");
                // Address attribute
                entity.Property(e => e.Address) .IsRequired(false).HasMaxLength(200).HasColumnType("nvarchar(200)");
                // isActive
                entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
                // Global Query Filter
                entity.HasQueryFilter(e => e.IsActive);
            });
            
        }
    }
}
