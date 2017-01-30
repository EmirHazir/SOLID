using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Solid.WebUI.Middlewares
{
    public static class ApplicationBuilderExtentions
    {
        //Burada wwwwroot u özelleştirdik aslında node packageleri buraya static olarak yolladık
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            //node nin pathi  //IO
            var path = Path.Combine(root,"node_modules");
            //Fiziksek pathi için provider
            var provider = new PhysicalFileProvider(path);

            // file i static yaptım
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules"; // senden Node-Modules diye birşey talep ettiğinde wwwroot
            options.FileProvider = provider; // bu file yukarıdaki fizisel pathte

            app.UseStaticFiles(options); // artık static bir file olarak kullan
            return app;
        }

    }
}
