using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ChainofResponsibility.Middleware;
public class AuthenticationsMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            Console.WriteLine("User authenticated.");
            // ادامه پردازش درخواست
            await _next(context);
        }
        else
        {
            Console.WriteLine("User not authenticated.");
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request Path: {context.Request.Path}");
        await _next(context); // ادامه پردازش درخواست
        Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
    }
}


public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // ادامه پردازش درخواست
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
            context.Response.StatusCode = 500; // Internal Server Error
            await context.Response.WriteAsync("An error occurred.");
        }
    }
}


