using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Vestager.Domain.Constants;
using Vestager.Domain.Entities;
using Vestager.Domain.Interfaces.Repositories;
using Vestager.Domain.Interfaces.UnitOfWork;
using Vestager.Infra.Data;
using Vestager.Infra.Repositories;
using Vestager.Infra.UnitOfWork;
using Vestager.MVC.Models;

namespace Vestager
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
            services.AddDbContext<Context>(c => c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<Context>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), CaminhoConstantes.ROOT)));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vestido, VestidoViewModel>()
                .IncludeAllDerived();

                cfg.CreateMap<VestidoViewModel, Vestido>().ConstructUsing(vm => vm.TipoVestido == VestidoConstantes.VESTIDO_LONGO ? (Vestido)new VestidoLongo() : (Vestido)new VestidoCurto());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);





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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
