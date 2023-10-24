using Microsoft.AspNetCore.Components;
using PokerPlanningDev.Components.Shared.BaseComponent;
using Shared.Models;
using Shared.Services.Interfaces;

namespace PokerPlanningDev.Pages.Room.Components.PlayResult;

public class PlayResultBase : BaseComponent
{
    #region Parameters
    [Parameter] public Guid RoomId { get; set; }
    [Parameter] public DuelResult DuelResult { get; set; }
    #endregion

    #region Dependencies
    [Inject] public ILivingRoomService LivingRoomService { get; set; }
    #endregion

    protected void Calculate()
    {
        LivingRoomService.Calculate(RoomId);
    }

    protected void ResetVotes()
    {
        LivingRoomService.ResetVotes(RoomId);
    }
}


