using Microsoft.AspNetCore.Components;
using MudBlazor;
using PokerPlanningDev.Components.Shared.BaseComponent;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace PokerPlanningDev.Pages.Room.Components.ParticipantDialog;

public class ParticipantDialogBase : BaseComponent
{
    #region Parametros
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }
    #endregion

    #region Dependnecies
    [Inject] private ILivingRoomService LivingRoomService { get; set; }
    #endregion

    #region Variables
    public string ParticipantName = string.Empty;
    #endregion

    protected void Submit()
    {
        try
        {
            MudDialog.Close(DialogResult.Ok(ParticipantName));
        }
        catch (CustomException ex)
        {
            SnackbarService.Add(ex.Message, Severity.Error);
        }
    } 
    protected void Cancel() => MudDialog.Cancel();
}