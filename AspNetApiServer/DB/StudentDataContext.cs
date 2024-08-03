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
        var connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["StudentDataContext"].ConnectionString;
        optionsBuilder.UseMySQL(connectionStr);
    }
}