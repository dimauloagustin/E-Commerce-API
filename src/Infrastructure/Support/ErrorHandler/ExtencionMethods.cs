using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Support.ErrorHandler.ErrorTemplates;
using Infrastructure.Support.ErrorHandler.Configuration;

namespace Infrastructure.Support.ErrorHandler
{
    public static class StatusServiceBuilder
    {
        public static IServiceCollection AddErrorHandlerService(this IServiceCollection services)
        {
            ErrorMapper mapper = new ErrorMapper();

            ConfigureExceptionHandler.Configure(mapper);

            services.AddSingleton(mapper);
            services.AddTransient<ErrorHandler>();


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
