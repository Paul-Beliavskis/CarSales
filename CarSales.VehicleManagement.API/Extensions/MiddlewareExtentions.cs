using CarSales.VehicleManagement.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace CarSales.VehicleManagement.API.Extensions
{
    public static class MiddlewareExtentions
    {
        public static void UseExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
