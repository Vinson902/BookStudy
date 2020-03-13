using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStudy.DBConnect;
using BookStudy.DBConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace BookStudy
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
            
           //  //get sql uri
           //  
           // // var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
           //  var databaseUri = new Uri("postgres://djyftvpmjxyern:17ea447c417c27ff9c38d93ad8ed5bdb59a5b84a0b1244110ecfb0c588183519@ec2-50-17-178-87.compute-1.amazonaws.com:5432/d5fs07chti6g70");
           //  var userInfo = databaseUri.UserInfo.Split(':');
           //
           //  var builder = new NpgsqlConnectionStringBuilder
           //  {
           //      Host = databaseUri.Host,
           //      Port = databaseUri.Port,
           //      Username = userInfo[0],
           //      Password = userInfo[1],
           //      Database = databaseUri.LocalPath.TrimStart('/'),
           //      SslMode = SslMode.Require,
           //      TrustServerCertificate = true
           //  };
           //
           //  string conn = builder.ToString();
            //get connection string from configure file
            string connection = Configuration.GetConnectionString("TestConnection");
            services.AddDbContext<ApplicationContext>(options =>
                // options.UseSqlServer(connection)
                options.UseNpgsql(connection));
            services.AddControllersWithViews();
            
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
