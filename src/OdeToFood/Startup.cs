using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OdeToFood.Services;
using Microsoft.AspNet.Routing;
using OdeToFood.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OdeToFood
{
    public class Startup
    {
        static string html = "<html><head><title>Hello!!!</title></head><body><h2>Hello World!!!{0}</h2></body></html>";
        public IConfiguration Config { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appconfig.json", false);

            Config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // ef
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<OdeToFoodDbContext>(
                    options => options.UseSqlServer(Config["database:connectionString"])
                );

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<OdeToFoodDbContext>();

            services.AddSingleton(provider => Config);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddTransient<IRestaurantData, SqlRestaurantData>();
            // request  => [Logger] => [Authorizer] => [Router] => [???Handle] =>
            // response <= return [Loger] <= return [Authorizer] <= return [Router]
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IGreeter greeter)
        {
            app.UseIISPlatformHandler();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRuntimeInfoPage("/info");

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(ConfigureRoute);

            app.Run(async (context) =>
            {
                var greeting = greeter.Greeting(html);
                await context.Response.WriteAsync(greeting);
            });
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("default",
                "{controller=Home}/{action=Index}/{id?}");
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
