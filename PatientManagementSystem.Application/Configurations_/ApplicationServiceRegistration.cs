using Microsoft.Extensions.DependencyInjection;
using PatientManagementSystem.Application.Commands;


namespace PatientManagementSystem.Application.Configurations_
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(AddPatientCommand).Assembly));

            return services;
        }

    }

}
