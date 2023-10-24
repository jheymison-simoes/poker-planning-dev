using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.ComponentsServices.Interfaces;

namespace PokerPlanningDev.Components.Shared.BaseComponent;

public class BaseComponent : ComponentBase
{
    #region Dependnecies
    [Inject] public ISnackbar SnackbarService { get; set; }
    [Inject] public ILoadingService LoadingService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public ILocalStorageService LocalStorageService { get; set; }
    [Inject] public IDialogService DialogService { get; set; }
    #endregion
}