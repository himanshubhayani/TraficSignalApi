using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Test.jwt.authentication;
using Test.data;
using Test.logic.Common;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Test.api
{
    public class Startup
    {
        public Autofac.IContainer ApplicationContainer { get; private set; }
        private IHostingEnvironment HostingEnvironment { get; set; }
        public IConfigurationRoot Configuration { get; }
        private string CurrentURL { get; set; }

        private string ConnectionString
        {
            get
            {
                return Configuration.GetConnectionString("DefaultConnection");
            }
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            this.HostingEnvironment = env;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //swagger integration start

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Test", Version = "v1" });
            });

            //swagger integration end

            // Add the whole configuration object here.
            services.AddSingleton<IConfiguration>(Configuration);

            // Add framework services.
            services.AddDbContext<TestContext>(options =>
                options.UseSqlServer(this.ConnectionString));

            TestContext.ConnectionString = this.ConnectionString;
            TestContext.SecretKey = Configuration.GetSection("JwtConfig:SecretKey").Value;
            TestContext.CurrentURL = Configuration.GetSection("JwtConfig:ValidIssuer").Value;
            TestContext.AppURL = Configuration.GetSection("JwtConfig:ValidAudience").Value;
            TestContext.TokenExpireMinute = Configuration.GetSection("JwtConfig:TokenExpireMinute").Value;

            services.AddMvc()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddDistributedMemoryCache();
            services.AddSession();

            // JWT - Start
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = Configuration.GetSection("JwtConfig:ValidIssuer").Value,
                            ValidAudience = Configuration.GetSection("JwtConfig:ValidAudience").Value,
                            IssuerSigningKey = JwtSecurityKey.Create(Configuration.GetSection("JwtConfig:SecretKey").Value)
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Member",
                    policy => policy.RequireClaim("Sid"));
            });
            // JWT - End

            // create a Autofac container builder
            var builder = new ContainerBuilder();

            // read service collection to Autofac
            builder.Populate(services);

            // use and configure Autofac
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterType<IFormFile>()
                .AsImplementedInterfaces().InstancePerDependency();

            // build the Autofac container
            ApplicationContainer = builder.Build(); ;

            // Set root path
            if (string.IsNullOrWhiteSpace(HostingEnvironment.WebRootPath))
            {
                HostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            CommonPath.RootPath = HostingEnvironment.WebRootPath;
            Paths.RootPath = HostingEnvironment.WebRootPath;

            // creating the IServiceProvider out of the Autofac container
            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IHostingEnvironment env, ILoggerFactory loggerFactory, TestContext context)
        {
            try
            {
                //swagger configuration start

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test V1");
                });

                //app.UseMvc();

                //swagger configuration end

                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    TestContext.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                    serviceScope.ServiceProvider.GetService<TestContext>()
                        .Database.Migrate();
                }

                //Cors
                app.UseCors(builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                    builder.AllowAnyOrigin(); // For anyone access.
                });

                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                app.UseAuthentication();
                app.UseStaticFiles();
                app.UseSession();
                app.UseMvc();

                // DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}