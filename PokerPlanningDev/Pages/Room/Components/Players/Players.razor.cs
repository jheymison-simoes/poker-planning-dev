using Microsoft.AspNetCore.Components;
using PokerPlanningDev.Components.Shared.BaseComponent;
using Shared.Models;

namespace PokerPlanningDev.Pages.Room.Components.Players;

public class PlayersBase : BaseComponent
{
    #region Parameters
    [Parameter] public List<Player> Players { get; set; } = new();
    [Parameter] public DuelResult DuelResult { get; set; }
    #endregion

    protected override void OnParametersSet()
    {
        Players = Players is null || !Players.Any() ? new() : Players;
        DuelResult = DuelResult;
    }
}