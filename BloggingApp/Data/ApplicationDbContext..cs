using Microsoft.EntityFrameworkCore;
using BloggingApp.Models;

namespace BloggingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and constraints here if needed.

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostId);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Comment>(entity =>
{
    entity.HasKey(e => e.CommentId);
    entity.Property(e => e.Text).IsRequired();
    entity.Property(e => e.CreatedAt).IsRequired();

    // Define a foreign key relationship between Comment and Post
    entity.HasOne<Post>(c => c.Post)  // Use Post type here, not Comment
          .WithMany(p => p.Comments)
          .HasForeignKey(c => c.PostId)
          .OnDelete(DeleteBehavior.Cascade);
});

        }
    }
}
