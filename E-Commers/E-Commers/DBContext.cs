using E_Commers.Entities;
using Microsoft.EntityFrameworkCore;

public class DBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DBContext(DbContextOptions options) : base(options)
    {
    }
}