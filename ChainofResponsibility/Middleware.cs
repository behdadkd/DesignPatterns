using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChainofResponsibility.Middleware
{
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
                await _next(context); // ادامه پردازش درخواست
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
    // کلاس Startup برای پیکربندی اپلیکیشن
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // اینجا سرویس‌ها اضافه می‌شوند (در صورت نیاز)
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // اضافه کردن میان‌افزارها به زنجیره پردازش
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<AuthenticationsMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello, World!");
            });
        }
    }

    // کلاس Program برای راه‌اندازی اپلیکیشن
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}



