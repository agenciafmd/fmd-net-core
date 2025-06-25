using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Fmd.Net.Core.Extensions;

public static class HealthChecksConfiguration
{
    public static void UseHealthCheckConfiguration(this IApplicationBuilder app, string? path = null, 
        string? uiPath = null)
    {
        app.UseHealthChecks(path ?? "/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(options =>
        {
            options.UIPath = uiPath ?? "/health-dashboard";
        });
    }
}