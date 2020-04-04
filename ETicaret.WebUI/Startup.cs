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
                options.Password.RequireDigit = false; // Say�sal de�er zorunlulu�u
                options.Password.RequireLowercase = false; // K���k harf zorunlulu�u
                options.Password.RequiredLength = 4; //min karakter zorunlulu�u
                options.Password.RequireNonAlphanumeric = false; // Alfanumerik karakter zorunlulu�u
                options.Password.RequireUppercase = false; // B�y�k harf zorunlulu�u

                options.Lockout.MaxFailedAccessAttempts = 50; // Ka� defa yanl�� girme hakk�
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); // Yanl�� girme hakk�ndan sonra bekleme s�resi
                options.Lockout.AllowedForNewUsers = false; // Yeni kullan�c� i�inde yanl�� girme hakk� varm� yokmu

                // options.User.AllowedUserNameCharacters = ""; buraya tan�t�lan karakterden ba�ka karakter username alan�nda kullan�lamaz
                options.User.RequireUniqueEmail = true; // Ayn� email ile olu�turamama

                options.SignIn.RequireConfirmedEmail = false; // Email onay� g�nderir
                options.SignIn.RequireConfirmedPhoneNumber = false; // Tel onay� g�nderir
            });

            services.ConfigureApplicationCookie(options =>
            {
                //options.LoginPath = "account/login";
                //options.LogoutPath = "account/logout";
                //options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie nin ya�ama s�resi
                options.SlidingExpiration = true; // Cookienin s�resinin tekrarlan�p tekrarlanmamas�
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true, // scriptler cookie ye ula�amaz
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
