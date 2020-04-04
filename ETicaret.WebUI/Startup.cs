using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaret.Business.Abstract;
using ETicaret.Business.Concrete;
using ETicaret.DataAccessLayer.Abstract;
using ETicaret.DataAccessLayer.Concrete;
using ETicaret.WebUI.Identity;
using ETicaret.WebUI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ETicaret.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false; // Sayýsal deðer zorunluluðu
                options.Password.RequireLowercase = false; // Küçük harf zorunluluðu
                options.Password.RequiredLength = 4; //min karakter zorunluluðu
                options.Password.RequireNonAlphanumeric = false; // Alfanumerik karakter zorunluluðu
                options.Password.RequireUppercase = false; // Büyük harf zorunluluðu

                options.Lockout.MaxFailedAccessAttempts = 50; // Kaç defa yanlýþ girme hakký
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); // Yanlýþ girme hakkýndan sonra bekleme süresi
                options.Lockout.AllowedForNewUsers = false; // Yeni kullanýcý içinde yanlýþ girme hakký varmý yokmu

                // options.User.AllowedUserNameCharacters = ""; buraya tanýtýlan karakterden baþka karakter username alanýnda kullanýlamaz
                options.User.RequireUniqueEmail = true; // Ayný email ile oluþturamama

                options.SignIn.RequireConfirmedEmail = false; // Email onayý gönderir
                options.SignIn.RequireConfirmedPhoneNumber = false; // Tel onayý gönderir
            });

            services.ConfigureApplicationCookie(options =>
            {
                //options.LoginPath = "account/login";
                //options.LogoutPath = "account/logout";
                //options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie nin yaþama süresi
                options.SlidingExpiration = true; // Cookienin süresinin tekrarlanýp tekrarlanmamasý
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true, // scriptler cookie ye ulaþamaz
                    Name = "ETicaret.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartManager>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseAuthentication();
            app.UseRouting();            
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default","{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "urunler",
                    template: "urunler/{category?}",
                    defaults: new { controller = "Home", action = "List" }
                );

                routes.MapRoute(
                    name: "sepet",
                    template: "sepet",
                    defaults: new { controller = "Cart", action = "Index" }
                );

            });

            SeedIdentity.Seed(userManager, roleManager, Configuration).Wait();
        }
    }
}
