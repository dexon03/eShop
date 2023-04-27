using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly);
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly);
        });
        
        return services;
    }
}