using Shared.ComponentsServices.Interfaces;

namespace Shared.ComponentsServices;

public class LoadingService : ILoadingService
{
    public event Action OnShow;
    public event Action OnHide;

    public bool _loading;

    public void Show()
    {
        if (_loading) return;
        OnShow?.Invoke();
        _loading = true;
    }
    
    public void Hide()
    {
        if (!_loading) return;
        OnHide?.Invoke();
        _loading = false;
    }

    public bool GetLoading() => _loading;
}