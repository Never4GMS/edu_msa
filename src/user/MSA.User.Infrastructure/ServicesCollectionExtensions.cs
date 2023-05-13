using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MSA.User.Infrastructure
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection UseUserDb(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("UserContext"))
                    .UseSnakeCaseNamingConvention();
            });
    }
}
