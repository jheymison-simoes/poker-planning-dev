using Microsoft.Extensions.DependencyInjection;
using Shared.ComponentsServices;
using Shared.ComponentsServices.Interfaces;
using Shared.Services;
using Shared.Services.Interfaces;

namespace PokerPlanningDev.Configurantion;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfig(this IServiceCollection services)
    {
        services.AddSingleton<ILivingRoomService, LivingRoomService>();
        services.AddScoped<ILoadingService, LoadingService>();
    } 
}