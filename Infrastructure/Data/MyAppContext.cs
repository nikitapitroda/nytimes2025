using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MyAppContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Article> Articles { get; set; }
    }
}
