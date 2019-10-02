using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using JobCoreApi.Models;
using Microsoft.EntityFrameworkCore;
using JobCoreApi.Data;
using Microsoft.AspNetCore.Identity;
using JobCoreApi.Models.Repository;

namespace JobCoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IDataAccessRepository<Employer>, ClsDAREmployer>();
            services.AddScoped<IDataAccessRepository<CompanyAddress>, ClsDARCompanyAddress>();

            services.AddScoped<IDataAccessRepository<JobList>, ClsDARJobList>();
            services.AddScoped<IDataAccessRepository<PersonalDetail>, ClsDARPersonalDetail>();
            services.AddScoped<IDataAccessRepository<Address>, ClsDARAddress>();
            services.AddScoped<IDataAccessRepository<Education>, ClsDAREducation>();
            services.AddScoped<IDataAccessRepository<Training>, ClsDARTraining>();
            services.AddScoped<IDataAccessRepository<Skill>, ClsDARSkill>();
            services.AddScoped<IDataAccessRepository<Experience>, ClsDARExperience>();
            services.AddScoped<IDataAccessRepository<ApplyJob>, ClsDARApplyJob>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
