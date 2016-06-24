using System.Data.Entity;

namespace EFModel
{
    public class EFModelContext : DbContext
    {
        public EFModelContext() : base("DefaultConnection") { }

        public DbSet<Role> Roles { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<AudioGenre> AudioGenres { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(e => e.RelatedMarks).WithRequired(e => e.User).WillCascadeOnDelete(false);
            modelBuilder.Entity<Role>().HasMany(e => e.Users).WithRequired(e => e.Role).WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>().HasMany(e => e.Cards).WithRequired(e => e.Category).WillCascadeOnDelete(false);
            modelBuilder.Entity<Card>().HasMany(e => e.Images).WithRequired(e => e.Card).WillCascadeOnDelete(false);
            modelBuilder.Entity<Card>().HasMany(e => e.AudioFiles).WithRequired(e => e.Card).WillCascadeOnDelete(false);
            modelBuilder.Entity<Card>().HasMany(e => e.TextFiles).WithRequired(e => e.Card).WillCascadeOnDelete(false);
            modelBuilder.Entity<Card>().HasMany(e => e.RelatedMarks).WithRequired(e => e.Card).WillCascadeOnDelete(false);
            modelBuilder.Entity<AudioGenre>().HasMany(e => e.AudioFiles).WithRequired(e => e.Genre).WillCascadeOnDelete(false);
        }

    }
}
