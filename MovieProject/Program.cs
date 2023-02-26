using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Middleware.Example;
using MovieProject.Data;
using MovieProject.Repository;
using MovieProject.Service;
using MvcMovie.Models;
using System.Globalization;

namespace MovieProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //PENDAFTARAN DEPENDENCY INJECTION
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();

            //MovieUtility.ConnString = builder?.Configuration.GetConnectionString("connstring");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    SeedData.Initialize(services);
            //}

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRequestCulture();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}