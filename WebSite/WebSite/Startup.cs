using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebSite
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

            services.AddMvc(options=>options.EnableEndpointRouting=false);
            //sayfay� refresh etti�imizde sayfan�n g�ncellenmesi i�in
            //paket y�neticisi konsolunu a��p �u kodu �al��t�r = Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation -Version 3.1.2
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //wwwroot un alt�ndaki css vb. dosyalar� eri�ime a�mak
            app.UseStaticFiles();
            //varsay�lan controller Home varsay�lan Metot Index Action Metot id opsiyonel(parametre olarak id yi alabilirizde almayabiliriz de)
            app.UseMvcWithDefaultRoute();


        }
    }
}
