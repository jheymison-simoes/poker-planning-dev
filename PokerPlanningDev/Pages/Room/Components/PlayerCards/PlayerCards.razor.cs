using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using PokerPlanningDev.Components.Shared.BaseComponent;
using Shared.Models;
using Shared.Services.Interfaces;

namespace PokerPlanningDev.Pages.Room.Components.PlayerCards;

public class PlayerCardsBase : BaseComponent
{
    #region Parameters
    [Parameter] public Guid RoomId { get; set; }
    [Parameter] public Guid PlayerId { get; set; }
    [Parameter] public List<VotingCard> Cards { get; set; } = new();
    #endregion

    #region Dependencies
    [Inject] public ILivingRoomService LivingRoomService { get; set; }
    #endregion

    #region Variables
    protected VotingCard CardSelected;
    #endregion

    protected override void OnParametersSet()
    {
        CardSelected = Cards is null || !Cards.Any()
            ? null
            : Cards.FirstOrDefault(c => c.Selected);
    }

    protected void SelectCard(VotingCard card)
    {
        if (CardSelected?.Id == card.Id)
        {
            Cards.ForEach(c => { c.Selected = false; });
            CardSelected = null;
            LivingRoomService.AddVote(RoomId, PlayerId, null);
            return;
        }

        Cards.ForEach(c => { c.Selected = c.Id == card.Id; });
        CardSelected = card;

        LivingRoomService.AddVote(RoomId, PlayerId, CardSelected);
    }
}