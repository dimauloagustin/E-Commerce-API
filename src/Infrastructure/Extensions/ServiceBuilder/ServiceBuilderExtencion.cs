using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Contexts;
using Infrastructure.Dependencies;
using Infrastructure.Dependencies.Abstractions;
using Infrastructure.Repository.EfCore;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.ServiceBuilder
{
    public static class ServiceBuilderExtencion
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFileStreamFactory, RealFileStreamFactory>();
            services.AddTransient<IFileSystemProvider, RealFileSystemProvider>();
            services.AddTransient<ILinkProvider, LinkProvider>();

            services.AddDbContext<BasicDbContext>(options =>
                //TODO - remove reference to startup project
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("E-Commers")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();

            services.AddTransient<IImageService, ImageService>();
        }
    }
}
