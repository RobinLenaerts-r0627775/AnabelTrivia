using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnabelTrivia.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Questions");
                entity.HasKey(e => e.ID);
                entity.Property(e => e.QuestionText).IsRequired();
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.Used).IsRequired();
            });
        }
    }
}