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
            //modelBuilder.Entity<Blog>();


            /// < Changes the name of Post Table into posts using Fluent API> ///
            //modelBuilder.Entity<Post>().ToTable("Posts");


            // learn this??
            //modelBuilder.Entity<Post>().Property(p => p.Title).HasColumnName("PostTitle");

            // changes the table name to Posts and the schema to Blogging
            modelBuilder.Entity<Post>().ToTable("Posts", schema: "Blogging");


            // changes the column name to PostTitle
            //modelBuilder.Entity<Blog>()
            //    .Property(b => b.Url).HasColumnName("BlogUrl");


            // changes the data type of the column to varchar(150)
            modelBuilder.Entity<Blog>(eb =>
            {
                eb.Property(b => b.Url).HasColumnType("varchar(150)");
                eb.Property(b => b.Url).IsRequired();
                eb.Property(b=> b.Url).HasMaxLength(200); // sets the max length of the column
                // makes the column not nullable
            });

        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
