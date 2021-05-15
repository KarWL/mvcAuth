using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mvcApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<mvcApp.Models.PropertyInfo> PropertyInfo { get; set; }
        
        public DbSet<mvcApp.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
