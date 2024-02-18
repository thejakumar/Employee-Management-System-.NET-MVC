﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace EmployeeManagement.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        { 
        
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
 