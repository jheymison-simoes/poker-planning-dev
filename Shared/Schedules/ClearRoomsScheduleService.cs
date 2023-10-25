using Hangfire;
using Hangfire.Console;
using Hangfire.Server;
using Microsoft.Extensions.Logging;
using Shared.Models;
using Shared.Schedules.Interfaces;
using Shared.Services.Interfaces;

namespace Shared.Schedules;

public class ClearRoomsScheduleService : IClearRoomsScheduleService
{
    private readonly ILogger<ClearRoomsScheduleService> _logger;
    private readonly ILivingRoomService _livingRoomService;
    private PerformContext _performContext;
    
    public ClearRoomsScheduleService(
        ILogger<ClearRoomsScheduleService> logger, 
        ILivingRoomService livingRoomService)
    {
        _logger = logger;
        _livingRoomService = livingRoomService;
    }
    
    public void Run()
    {
        RecurringJob.AddOrUpdate("Clear",
            () => Clear(null),
            Cron.Never,
            TimeZoneInfo.Utc
        );
    }

    public void Clear(PerformContext context)
    {
        _performContext = context;
        
        LogInformation("Iniciando processo de limpeza das salas!");

        var rooms = _livingRoomService.GetRooms();
        if (!rooms.Any())
        {
            LogInformation("Não há nenhuma sala pra ser limpa!");
            return;
        }

        var countRooms = rooms.Count;
        
        rooms = new List<LivingRoom>();
        _livingRoomService.SetRooms(rooms);
        
        LogInformation($"Foram limpadas {countRooms} salas!");
    }
    
    #region Private Methods

    private void LogInformation(string message)
    {
        _performContext.WriteLine(message);
        _logger.LogInformation(message);
    }

    #endregion
}