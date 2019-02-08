using MetadataService.Authorization;
using MetadataService.Infrastructure;
using MetadataService.Infrastructure.Entities;
using MetadataService.Services;
using MetadataService.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MetadataService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                options =>
                {
                    options.Filters.Add(new AuthorizationFilterFactory());
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //database connect string in appsettings.json
            services.AddDbContext<MetadataContext>(options =>
              options.UseSqlServer(
                Configuration.GetConnectionString("MetadataService"),
                b => b.MigrationsAssembly("MetadataService")));

            // repositories
            services.AddScoped<IRepository<Theme>, Repository<Theme>>();
            services.AddScoped<IRepository<VideoInfo>, Repository<VideoInfo>>();
            services.AddScoped<IRepository<CmsContent>, Repository<CmsContent>>();
            services.AddScoped<IRepository<AuthorizationCookie>, Repository<AuthorizationCookie>>();

            // services
            services.AddScoped<IThemeService, ThemeService>();
            services.AddScoped<ICmsContentService, CmsContentService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IMetadataService, Services.Implementations.MetadataService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(
              routes =>
              {
                  routes.MapRoute(
              name: "incoming",
              template: "/incoming/{controller}/{action}/{id?}");
                  routes.MapRoute(
              name: "default",
              template: "{controller=ResourceProvider}/{action}/{id}");
              }
          );
        }
    }
}
