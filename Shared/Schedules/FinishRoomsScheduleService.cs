using Hangfire;
using Hangfire.Console;
using Hangfire.Server;
using Microsoft.Extensions.Logging;
using Shared.Schedules.Interfaces;
using Shared.Services.Interfaces;

namespace Shared.Schedules;

public class FinishRoomsScheduleService : IFinishRoomsScheduleService
{

    private readonly ILogger<FinishRoomsScheduleService> _logger;
    private readonly ILivingRoomService _livingRoomService;
    private PerformContext _performContext;

    private const int MaxHour = -3;

    public FinishRoomsScheduleService(
        ILogger<FinishRoomsScheduleService> logger, 
        ILivingRoomService livingRoomService)
    {
        _logger = logger;
        _livingRoomService = livingRoomService;
    }

    public void Run()
    {
        RecurringJob.AddOrUpdate("Finish",
            () => Finish(null),
            "0 */3 * * *",
            TimeZoneInfo.Utc
        );
    }
    
    public void Finish(PerformContext context)
    {
        _performContext = context;
        
        LogInformation("Iniciando processo de limpeza das salas");
        
        var rooms = _livingRoomService.GetRooms();
        if (!rooms.Any())
        {
            LogInformation("Não há nenhuma sala criada!");
            return;
        }

        var currentDate = DateTime.UtcNow.AddHours(MaxHour);

        var roomsRemove = rooms.Where(r => currentDate > r.CreatedAt).ToList();
        if (!roomsRemove.Any())
        {
            LogInformation("Não há nenhuma sala para ser limpa!");
            return;
        }

        foreach (var roomRemove in roomsRemove) rooms.Remove(roomRemove);
        
        _livingRoomService.SetRooms(rooms);
        
        LogInformation($"Foram removidas {roomsRemove.Count} salas!");
    }

    #region Private Methods

    private void LogInformation(string message)
    {
        _performContext.WriteLine(message);
        _logger.LogInformation(message);
    }

    #endregion
}