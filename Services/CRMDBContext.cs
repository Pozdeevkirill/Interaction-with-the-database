using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class CRMDBContext : DbContext
    {
        public CRMDBContext(DbContextOptions<CRMDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<EmployeeViewModel> Employees { get; set; }
    }
}
