using Blazored.LocalStorage;
using PokerPlanningDev.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAppSettingsConfig(builder.Configuration);
builder.Services.AddMudServiceConfig();
builder.Services.AddDependencyInjectionConfig();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHangFireConfiguration();
builder.Services.AddSchedules();

var app = builder.Build();
var serviceProvider = app.Services.GetService<IServiceProvider>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseHangfire(serviceProvider);

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

serviceProvider.AddSchedulesRun();

app.Run();
