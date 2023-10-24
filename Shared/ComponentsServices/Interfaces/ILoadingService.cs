using System;

namespace Shared.ComponentsServices.Interfaces;

public interface ILoadingService
{
    event Action OnShow;
    event Action OnHide;
    void Show();
    void Hide();
}