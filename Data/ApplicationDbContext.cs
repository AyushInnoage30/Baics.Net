using EmployeeAdmin.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdmin.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<Employee> MyProperty { get; set; }
    }
}
