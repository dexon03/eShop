using Application.Data;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddDbContext<DbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
        return services;
    }
}