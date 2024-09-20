using AspNetApiServer.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace AspNetApiServer.DB;

public class StudentDataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionStr = Environment.GetEnvironmentVariable("DB_CONNECTION_STR") 
                            ?? System.Configuration.ConfigurationManager.ConnectionStrings["StudentDataContext"].ConnectionString;
        
        optionsBuilder.UseMySQL(connectionStr);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Student>().ToTable("students");
    }
}