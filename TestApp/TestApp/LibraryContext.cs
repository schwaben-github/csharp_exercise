using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class LibraryContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Optional: Retrieve connection details from environment variables or configuration
            var server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
            var database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "LibraryDB";
            var userId = Environment.GetEnvironmentVariable("DB_USER_ID");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            string connectionString;

            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(password))
            {
                // Use SQL Server Authentication
                connectionString = $"Server= BE2CG976\\SQLEXPRESS;Database= Knjiznica;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
            }
            else
            {
                // Use Integrated Security (Windows Authentication)
                connectionString = $"Server= BE2CG976\\SQLEXPRESS;Database= Knjiznica;Integrated Security=True;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
            }

            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasKey(m => m.ClanId);
        }
    }
}