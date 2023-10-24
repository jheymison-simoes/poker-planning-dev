using Microsoft.AspNetCore.Components;
using Shared.ComponentsServices.Interfaces;

namespace PokerPlanningDev.Components.Shared.Loading;

public class LoadingBase : ComponentBase
{
    #region Dependencias
    [Inject] private ILoadingService LoadingService { get; set; }
    #endregion

    #region Variaveis
    protected bool IsVisible;
    #endregion
    
    #region Metodos
    protected override void OnInitialized()
    {
        LoadingService.OnShow += Show;
        LoadingService.OnHide += Hide;
    }

    #endregion
    #region Metodos Privados
    private void Show()
    {
        IsVisible = true;
        StateHasChanged();
    }
    
    private void Hide()
    {
        IsVisible = false;
        StateHasChanged();
    }
    #endregion
}