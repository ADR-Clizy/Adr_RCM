/*
*
* (c) 2021-2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using Andromede.Authentication;
using Blazored.Modal;
using Blazored.SessionStorage;
using DatabaseConnection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Andromede
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AndromedeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RestorerConnection")));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredSessionStorage();
            services.AddBlazoredModal();
            services.AddScoped<AuthenticationStateProvider, AndromedeAuthenticationStateProvider>();
            services.AddScoped<IRestorerRepository, SQLRestorerRepository>();
            services.AddScoped<ICardRepository, SQLCardRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
