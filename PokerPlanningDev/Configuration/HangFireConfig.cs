using Hangfire;
using Hangfire.Console;
using HangfireBasicAuthenticationFilter;
using Shared.Models;

namespace PokerPlanningDev.Configuration;

public static class HangFireConfig
{
    public static void AddHangFireConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<AutomaticRetryAttribute>();
        
        services.AddHangfire((provider, config) =>
        {
            config.UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseInMemoryStorage()
                .UseFilter(provider.GetRequiredService<AutomaticRetryAttribute>());

            config.UseConsole();
        });
        
        
        services.AddHangfireServer(serverOptions =>
        {
            serverOptions.ServerName = "Dashboard Poker Planning Dev";
        });
    }
    
    public static void UseHangfire(this IApplicationBuilder app, IServiceProvider serviceProvider)
    {
        var appSettings = serviceProvider.GetRequiredService<AppSettings>();
        
        app.UseHangfireDashboard(options: new DashboardOptions()
        {
            DashboardTitle = "Dashboard Poker Planning Dev",
            Authorization = new[]
            {
                new HangfireCustomBasicAuthenticationFilter{
                    User = appSettings.HangFireUser ?? "admin",
                    Pass = appSettings.HangFirePassword ?? "admin",
                }
            },
            IsReadOnlyFunc = _ => false,
        });
    }
}