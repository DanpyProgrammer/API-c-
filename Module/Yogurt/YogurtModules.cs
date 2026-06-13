namespace yogurtApi.Module.Yogurts;

using yogurtApi.Module.Yogurt.Services;

public static class YogurtModules
{
    public static IServiceCollection AddYogurtModule(this IServiceCollection services)
    {
        services.AddScoped<YogurtService>();

        return services;
    }
}