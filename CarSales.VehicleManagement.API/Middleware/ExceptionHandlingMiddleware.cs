using System;
using System.Net.Mime;
using System.Threading.Tasks;
using CarSales.VehicleManagement.API.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CarSales.VehicleManagement.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleAPIExceptionAsync(ex, httpContext);
            }
        }

        public async Task HandleAPIExceptionAsync(Exception exception, HttpContext httpContext)
        {
            var exceptionModel = new ExceptionModel();

            if (exception is VehicleNotFoundException vehicleNotFoundException)
            {
                exceptionModel.Errors.Add(vehicleNotFoundException.Message);
                httpContext.Response.StatusCode = 404;
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            }
            else if (exception is InvalidVehicleTypeException invalidVehicleTypeException)
            {
                exceptionModel.Errors.Add(invalidVehicleTypeException.Message);
                httpContext.Response.StatusCode = 400;
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            }
            else
            {
                //Should never get here
                exceptionModel.Errors.Add("An unhandled exception occured");
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;

            }

            var responseJson = JsonConvert.SerializeObject(exceptionModel);
            await httpContext.Response.WriteAsync(responseJson);
        }
    }
}
