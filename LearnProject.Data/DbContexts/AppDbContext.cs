using LearnProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnProject.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; }
}
