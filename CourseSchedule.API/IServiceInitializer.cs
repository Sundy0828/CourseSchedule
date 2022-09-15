using Microsoft.Extensions.DependencyInjection.Extensions;

public interface IServiceInitializer
{
    void Initialize();
}
public static class IServicesExtensions
{
    public static IServiceCollection AddServiceInitializer<T>(this IServiceCollection services) where T : IServiceInitializer
    {
        services.TryAddSingleton(typeof(IServiceInitializer), typeof(T));
        return services;
    }
}
