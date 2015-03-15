using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using Weapsy.Models;
using Weapsy.Blog.DependencyResolver;

namespace Weapsy
{
	public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            services.AddEntityFramework(Configuration)
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>();

            // Add Identity services to the services container.
            services.AddIdentity<ApplicationUser, IdentityRole>(Configuration)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add MVC services to the services container.
            services.AddMvc();

			// Uncomment the following line to add Web API servcies which makes it easier to port Web API 2 controllers.
			// You need to add Microsoft.AspNet.Mvc.WebApiCompatShim package to project.json
			// services.AddWebApiConventions();

			//Services.RegisterBlogServices(services);
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Configure the HTTP request pipeline.
            // Add the console logger.
            loggerfactory.AddConsole();

            // Add the following to the request pipeline only in development environment.
            if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });







			//// Autofac
			//var builder = new ContainerBuilder();
			//builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());
			//IContainer container = builder.Build();
			//// Replace the default container
			//app.ApplicationServices = container.Resolve<IServiceProvider>();




			//app.UseServices(services =>
			//{
			//	// Add MVC services.
			//	services.AddMvc();

			//	// Add our own services.
			//	var builder = new ContainerBuilder();
			//	RegisterServices(builder);
			//	builder.Populate(services);

			//	// Create container.
			//	var container = builder.Build();
			//	return container.Resolve<IServiceProvider>();
			//});





			//app.UseServices(services =>
			//{
			//	services.AddMvc();
			//	services.AddSingleton<PassThroughAttribute>();
			//	services.AddSingleton<UserNameService>();
			//	services.AddTransient<ITestService, TestService>();

			//	// Setup services with a test AssemblyProvider so that only the
			//	// sample's assemblies are loaded. This prevents loading controllers from other assemblies
			//	// when the sample is used in the Functional Tests.
			//	services.AddTransient<IAssemblyProvider, TestAssemblyProvider<Startup>>();
			//	services.ConfigureMvcOptions(options =>
			//	{
			//		options.Filters.Add(typeof(PassThroughAttribute), order: 17);
			//		options.AddXmlDataContractSerializerFormatter();
			//		options.Filters.Add(new FormatFilterAttribute());
			//	});
			//	services.ConfigureRazorViewEngineOptions(options =>
			//	{
			//		var expander = new LanguageViewLocationExpander(
			//			context => context.HttpContext.Request.Query["language"]);
			//		options.ViewLocationExpanders.Insert(0, expander);
			//	});

			//	// Create the autofac container
			//	ContainerBuilder builder = new ContainerBuilder();

			//	// Create the container and use the default application services as a fallback
			//	AutofacRegistration.Populate(
			//		builder,
			//		services);

			//	builder.RegisterModule<MonitoringModule>();

			//	IContainer container = builder.Build();

			//	return container.Resolve<IServiceProvider>();
			//});

			//app.UseServices(services =>
			//{
			//	// Create the autofac container
			//	ContainerBuilder builder = new ContainerBuilder();

			//	// Create the container and use the default application services as a fallback
			//	AutofacRegistration.Populate(
			//		builder,
			//		services);



			//	IContainer container = builder.Build();

			//	return container.Resolve<IServiceProvider>();
			//});
		}
	}
}
