using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPIDemo.Data;

namespace WebAPIDemo.Context
{
    public partial class LoginFlowDBContext : IdentityDbContext<Users>
    {
        public LoginFlowDBContext(DbContextOptions<LoginFlowDBContext> options)
            : base(options)
        {
        }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(t => t.HasKey(u => u.Id));
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
