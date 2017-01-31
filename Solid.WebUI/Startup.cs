using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Solid.Services.SSAbstract;
using Solid.Services.SSConcrete;
using Solid.Data.SDAbstract;
using Solid.Data.SDConcrete.SDEntityFramework;
using Solid.WebUI.Middlewares;
using Solid.WebUI.UIServicesforSessionManage;
using Solid.WebUI.SWEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

namespace Solid.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Productların sayfalarda gösterilmesi için tanıtımı buraya şart
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            //Categorilerin sayfalarda  için tanıtımı buraya şart
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            //Cartların sayfalar için tanıtımı
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService, CartService>();
            //Genişlettiğimiz Session  için tanıtımı buraya şart
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Session  için tanıtımı buraya şart
            services.AddSession();
            //Sessionu bellekte tutmak  için tanıtımı buraya şart
            services.AddDistributedMemoryCache(); // bunu eklemezsen Session çalışmaz
            //CustomIdentityDbContexti eklememiz şart
            services.AddDbContext<CostomIdentityDbContext>(options => options.UseSqlServer(@"Data Source=.;Database=NORTHWND;User ID=sa;Password=123;"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CostomIdentityDbContext>()
                .AddDefaultTokenProviders();



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseStaticFiles(); Middleware klasörü içinde yazdğım statik class ApplicationBuilderExtentions
            app.UseIdentity();
            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseSession();//Hataları yakalar sessionla ilgili

            //Routing Olayı
            app.UseMvc(ConfigureConfig);
        }

        private void ConfigureConfig(IRouteBuilder obj)
        {
            //Product/Index
            obj.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}");
        }
    }
}
