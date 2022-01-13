using Indra.Infrastructure.Persistence;
using Indra.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Indra.Application.Services.Jwt.Extensions;

namespace Indra.Application.Services
{
    public class DIConfiguration
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddJWTTokenServices(Configuration);
        }
    }
}
