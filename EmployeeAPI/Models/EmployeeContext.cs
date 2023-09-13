using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeeAPI.Models
{
    public class EmployeeContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public EmployeeContext(IConfiguration configuration) =>
            Configuration = configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=EmployeeDB;Username=postgres;Password=kyG=7-9w");

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
    }
}
