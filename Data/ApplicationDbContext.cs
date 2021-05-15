using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcApp.Models;

namespace mvcApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<mvcApp.Models.PropertyInfo> PropertyInfo { get; set; }
        
        public DbSet<mvcApp.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
