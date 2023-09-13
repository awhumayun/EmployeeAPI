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
            => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
    }
}
