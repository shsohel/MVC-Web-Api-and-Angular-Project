using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JobCoreApi.Models;

namespace JobCoreApi.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<JobList> JobLists { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }

        public DbSet<PersonalDetail> PersonalDetails { get; set; }
        public DbSet<ApplyJob> ApplyJobs { get; set; }

    }
}
