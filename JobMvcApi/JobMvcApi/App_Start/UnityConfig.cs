using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi; // You must be use unity controller 
using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using JobMvcApi.Controllers;

namespace JobMvcApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            //Add New 

            container.RegisterType<AccountController>(new InjectionConstructor());


            /////Class Inject 
            //container.RegisterType<ApplyJob>(new InjectionConstructor());
            //container.RegisterType<JobList>(new InjectionConstructor());
            //container.RegisterType<PersonalDetail>(new InjectionConstructor());






            container.RegisterType<IDataAccessRepository<Employer, int>, DAREmployer>();
            container.RegisterType<IDataAccessRepository<CompanyAddress, int>, DARCompanyAddress>();
            container.RegisterType<IDataAccessRepository<JobList, int>, DARJobList>();
            container.RegisterType<IDataAccessRepository<PersonalDetail, int>, DARPersonalDetail>();
            container.RegisterType<IDataAccessRepository<Experience, int>, DARExperience>();
            container.RegisterType<IDataAccessRepository<Education, int>, DAREducation>();
            container.RegisterType<IDataAccessRepository<Skill, int>, DARSkill>();
            container.RegisterType<IDataAccessRepository<Training, int>, DARTraining>();
            container.RegisterType<IDataAccessRepository<Address, int>, DARAddress>();
            container.RegisterType<IDataAccessRepository<ApplyJob, int>, DARApplyJob>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}