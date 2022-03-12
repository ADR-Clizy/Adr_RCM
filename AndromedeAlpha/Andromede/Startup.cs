/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using Andromede.Authentication;
using Blazored.Modal;
using Blazored.LocalStorage;
using DatabaseConnection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using Andromede.Pages.Tools;

namespace Andromede
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AndromedeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AndromedeDbConnection")));
            //services.AddMvc().AddNewtonsoftJson();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredLocalStorage();
            services.AddBlazoredModal();
            services.AddScoped<AuthenticationStateProvider, AndromedeAuthenticationStateProvider>();
            services.AddScoped<IPdfFileManager, PdfFileManager>();
            services.AddScoped<IRestorerRepository, SQLRestorerRepository>();
            services.AddScoped<ICardRepository, SQLCardRepository>();
            services.AddScoped<IRestorerClaimRepository, SQLRestorerClaimRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseDeveloperExceptionPage();
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
                endpoints.MapControllers();
            });
        }
    }
}
