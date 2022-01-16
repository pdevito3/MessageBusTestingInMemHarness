namespace RecipeManagement.Extensions.Services;

using RecipeManagement.Databases;
using RecipeManagement.Resources;
using Microsoft.EntityFrameworkCore;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        // DbContext -- Do Not Delete
        if (env.IsEnvironment(LocalConfig.FunctionalTestingEnvName) || env.IsDevelopment())
        {
            services.AddDbContext<RecipesDbContext>(options =>
                options.UseInMemoryDatabase($"RecipeManagement"));
        }
        else
        {
            services.AddDbContext<RecipesDbContext>(options =>
                options.UseNpgsql(
                    Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? "placeholder-for-migrations",
                    builder => builder.MigrationsAssembly(typeof(RecipesDbContext).Assembly.FullName))
                            .UseSnakeCaseNamingConvention());
        }

        // Auth -- Do Not Delete
    }
}
