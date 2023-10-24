using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace PokerPlanningDev.Components.Layout;

public class MainLayoutBase : LayoutComponentBase
{
    protected ErrorBoundary ErrorBoundary;

    protected MudTheme MyCustomTheme = new MudTheme()
    {
        Palette = new PaletteLight()
        {
            Primary = Colors.Teal.Darken1,
            Secondary = Colors.Grey.Lighten5,
            Error = Colors.Red.Darken1,
            Success = Colors.Teal.Darken1,
            Info = Colors.Blue.Darken1,
            Warning = Colors.Yellow.Darken1,
        },
        PaletteDark = new PaletteDark()
        {
            Primary = Colors.Teal.Darken1,
            Secondary = Colors.Grey.Lighten5,
            Error = Colors.Red.Darken1,
            Success = Colors.Teal.Darken1,
            Info = Colors.Blue.Darken1,
            Warning = Colors.Yellow.Darken1,
        },
    };
    
    protected override void OnParametersSet()
    {
        ErrorBoundary?.Recover();
    }
}