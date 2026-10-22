using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RhProject.Application.Interfaces.Security;
using RhProject.Domain.Interfaces.Repository;
using RhProject.Infrastructure.Configurations;
using RhProject.Infrastructure.Context;
using RhProject.Infrastructure.Repositories;
using RhProject.Infrastructure.Security;

namespace RhProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RhContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ICooperadoRepository, CooperadoRepository>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}