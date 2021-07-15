using Microsoft.Extensions.DependencyInjection;

namespace E_Commers.Errors.Extensions.ServiceBuilder
{
    public static class ServiceBuilderExtencion
    {
        public static void AddErrorManager(this IServiceCollection services)
        {
            services.AddSingleton(new ErrorManagerConfiguration().Configure(new ErrorManager()));
        }
    }
}
