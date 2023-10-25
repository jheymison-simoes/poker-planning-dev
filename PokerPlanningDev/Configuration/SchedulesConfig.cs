using Shared.Schedules;
using Shared.Schedules.Interfaces;

namespace PokerPlanningDev.Configuration;

public static class SchedulesConfig
{
    public static void AddSchedules(this IServiceCollection services)
    {
        services.AddSingleton<IFinishRoomScheduleService, FinishRoomScheduleService>();
    }
    
    public static void AddSchedulesRun(this IServiceProvider serviceProvider)
    {
        serviceProvider.GetService<IFinishRoomScheduleService>()?.Run();
    }
}