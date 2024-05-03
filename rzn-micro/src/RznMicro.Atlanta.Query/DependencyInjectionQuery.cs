using Microsoft.Extensions.DependencyInjection;

namespace RznMicro.Atlanta.Query;

public static class DependencyInjectionQuery
{
    public static void AddApplicationQuery(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjectionQuery).Assembly));
    }
}
