using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;
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
                webBuilder.ConfigureServices(services =>
                {
                    services.AddDistributedMemoryCache(); // Thêm bộ nhớ phân tán
                    services.AddSession(options =>
                    {
                        options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
                        options.Cookie.HttpOnly = true;  // Đảm bảo cookie chỉ được truy cập qua HTTP (không qua JavaScript)
                        options.Cookie.IsEssential = true;  // Đánh dấu cookie là cần thiết cho ứng dụng
                    });
                    services.AddControllersWithViews();
                });
                webBuilder.Configure(app =>
                {
                    app.UseSession(); // Sử dụng session
                    app.UseRouting();
                    app.UseStaticFiles();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                    });
                });
            });
}
