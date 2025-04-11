using Microsoft.Extensions.DependencyInjection;
using PatientManagementSystem.Application.Interfaces;
using PatientManagementSystem.Infrastracture.Repositories;


namespace PatientManagementSystem.Infrastracture.Configurations_
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IPatientRepo, PatientRepo>();
            return services;
        }
    }
}
