using EFCore2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore2
{
    internal class ApplicationDbContext : DbContext
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCore2ndTraining;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Post>();

            // changes the table name to Posts and the schema to Blogging
            modelBuilder.Entity<Post>().ToTable("Posts", schema: "Blogging");

            // changes the data type of the column to varchar(150)
            modelBuilder.Entity<Blog>(eb =>
            {
                eb.Property(b => b.Url).HasColumnType("varchar(150)");
                eb.Property(b => b.Url).IsRequired();
                eb.Property(b => b.Url).HasMaxLength(200); // sets the max length of the column
                                                           // makes the column not nullable

                // adds a comment to the column
                eb.Property(b => b.Url).HasComment("This is a comment in the database, behind Posts");

                eb.Property(b => b.Date).HasDefaultValueSql("getdate()");
            });


            // changes to be a primary key using fluentAPI and chaging it's namme
            modelBuilder.Entity<Book>(ev =>
            {
                ev.HasKey(e => e.BookKey).HasName("PK_Book");
            });

            modelBuilder.Entity<Author>(eb =>
            {
                eb.Property(b => b.DisplayName).
                HasComputedColumnSql("[L_name] + ', ' + [F_name]");
            });


            // Same of what i did on the Category.cs file but using FluentAPI
            modelBuilder.Entity<Category>(eb =>
            {
                eb.Property(b => b.CategoryId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Category>()
                .HasOne<Book>(s => s.Books)
                .WithOne(ad => ad.Category)
                .HasForeignKey<Category>(ad => ad.BookID);
        }



        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
