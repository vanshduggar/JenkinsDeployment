using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDAPI.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> opt) : base(opt)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
