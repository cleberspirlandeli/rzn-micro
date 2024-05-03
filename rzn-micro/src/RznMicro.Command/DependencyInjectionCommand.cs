using Microsoft.Extensions.DependencyInjection;

namespace RznMicro.Atlanta.Command;

public static class DependencyInjectionCommand
{
    public static void AddApplicationCommand(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjectionCommand).Assembly));
    }
}
