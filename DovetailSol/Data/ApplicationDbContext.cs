using Microsoft.EntityFrameworkCore;
using DovetailSol.Models;

namespace DovetailSol.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<EMP> EMP { get; set; }
    }
}
