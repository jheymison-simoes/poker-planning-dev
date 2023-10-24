﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PokerPlanningDev.Components.Shared.BaseComponent;
using Shared.Exceptions;
using Shared.Models;
using Shared.Services.Interfaces;

namespace PokerPlanningDev.Pages.Home;

public class HomeBase : BaseComponent
{

    #region Dependencies
    [Inject] private ILivingRoomService LivingRoomService { get; set; }
    #endregion

    #region Objects
    protected EditContext EditContext;
    protected LivingRoomForm Form = new();
    #endregion

    protected override void OnInitialized()
    {
        EditContext = new(Form);
    }
    
    protected void OnValidSubmit(EditContext editContext)
    {
        try
        {
            if (!editContext.Validate()) return;

            LoadingService.Show();
            var room = LivingRoomService.CreateRoom(Form.Name);
            NavigationManager.NavigateTo($"/Room/{room.Id}");
        }
        catch (CustomException ex)
        {
            SnackbarService.Add(ex.Message, Severity.Error);
        }
        finally
        {
            LoadingService.Hide();
        }
    }
}