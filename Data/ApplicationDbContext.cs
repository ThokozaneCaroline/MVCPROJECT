using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ItdevFinalProject.Models;

namespace ItdevFinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ItdevFinalProject.Models.Company> Company { get; set; }
        public DbSet<ItdevFinalProject.Models.EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<ItdevFinalProject.Models.PaymentInfo> PaymentInfo { get; set; }
        public DbSet<ItdevFinalProject.Models.WorkInfo> WorkInfo { get; set; }
        public DbSet<ItdevFinalProject.Models.JobInfo> JobInfo { get; set; }
    }
}
