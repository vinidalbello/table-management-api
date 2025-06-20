using Microsoft.EntityFrameworkCore;
using TableManagement.Models;

namespace TableManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Table> Tables { get; set; }
    }
}