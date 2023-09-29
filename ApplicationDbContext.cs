using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public ApplicationDbContext(IConfiguration configuration) { 
        Configuration = configuration;
    }

    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultAzureConnection"));
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
    modelBuilder.Entity<User>().HasData(
        new User { 
            Id = 1, 
            UserName = "TrustyTea",
            FirstName = "Ryan",
            LastName = "Flores",
            Email = "rryanflorres@gmail.com",
            PasswordHash = "asdfafdasdfasdf",
            Salt = "asdf"
            }
    );
    }
}
