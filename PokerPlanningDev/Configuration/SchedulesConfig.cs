using Shared.Schedules;
using Shared.Schedules.Interfaces;

namespace PokerPlanningDev.Configuration;

public static class SchedulesConfig
{
    public static void AddSchedules(this IServiceCollection services)
    {
        services.AddSingleton<IFinishRoomsScheduleService, FinishRoomsScheduleService>();
        services.AddSingleton<IClearRoomsScheduleService, ClearRoomsScheduleService>();
    }
    
    public static void AddSchedulesRun(this IServiceProvider serviceProvider)
    {
        serviceProvider.GetService<IFinishRoomsScheduleService>()?.Run();
        serviceProvider.GetService<IClearRoomsScheduleService>()?.Run();
    }
}