using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebApplication1.Models;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 16,
                   Name = "Test",
                   Department = Dept.IT,
                   Email = "test@gmail.com",
                   PhotoPath = ""
               }
               );
        }
    }
}
