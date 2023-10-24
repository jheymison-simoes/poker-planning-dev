using Microsoft.AspNetCore.Components;
using MudBlazor;
using PokerPlanningDev.Components.Shared.BaseComponent;
using PokerPlanningDev.Pages.Room.Components.ParticipantDialog;
using Shared.Exceptions;
using Shared.Helpers;
using Shared.Models;
using Shared.Services.Interfaces;

namespace PokerPlanningDev.Pages.Room;

public class RoomBase : BaseComponent, IDisposable
{
    #region Parameters
    [Parameter] public Guid RoomId { get; set; }
    #endregion

    #region Dependencies
    [Inject] private ILivingRoomService LivingRoomService { get; set; }
    #endregion
    
    #region Lists
    protected LivingRoom Room;
    #endregion

    #region Variables
    protected Player Player;
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) await InitAsync();
    }
    
    public void Dispose()
    {
        LivingRoomService.AddPlayerHandler -= UpdateRoom;
    }
    
    #region Private Methods
    private async Task InitAsync()
    {
        try
        {
            Room = LivingRoomService.GetById(RoomId);
            await GetParticipantInCacheAsync();
            LivingRoomService.AddPlayerHandler += UpdateRoom;
        }
        catch (CustomException ex)
        {
            SnackbarService.Add(ex.Message, Severity.Error);
            NavigationManager.NavigateTo("/");
        }
        finally
        {
            await InvokeAsync(StateHasChanged);
        }
    }
    
    private async Task GetParticipantInCacheAsync()
    {

        var player = await LocalStorageService.GetItemAsync<Player>(PlayerConstants.PlayerCacheKey);
        if (player is null)
        {
            var closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true, CloseButton = true};
            var dialog = await DialogService.ShowAsync<ParticipantDialog>("Entrar como participante", closeOnEscapeKey);
            var result = await dialog.Result;

            player = new Player(result.Data.ToString()!);
        }
        
        player = LivingRoomService.AddParticipant(Room.Id, player.Name);

        await LocalStorageService.SetItemAsync(PlayerConstants.PlayerCacheKey, player);

        Player = player;
    }

    private void UpdateRoom(object sender, EventArgs ev)
    {
        Room = LivingRoomService.GetById(RoomId); 
        InvokeAsync(StateHasChanged);
    }
    #endregion
}
