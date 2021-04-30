using System;
using Contact.Manager.Users.Api.Behaviors;
using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Contact.Manager.Users.Infrastructure.Context;
using Contact.Manager.Users.Domain.Repositories;
using Contact.Manager.Users.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Contact.Manager.Users.Api.Models;
using System.Reflection;
using System.IO;
using Contact.Manager.Users.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Contact.Manager.Users.Api.Settings;

namespace Contact.Manager.Users
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
            services.AddControllers();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<IDbContext, DbContext>();
            services.AddTransient<IUserRepository, UserRepository>();

            SwaggerConfigureService(services);
            AuthenticationConfigureService(services);
            services.AddTransient<IJwtAuthenticationService, JwtAuthenticationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{ApiInfo.Version}/swagger.json", $"{ApiInfo.Name} {ApiInfo.Version}");
                c.ShowExtensions();
            });
            app.UseSwagger();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SwaggerConfigureService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiInfo.Version, new OpenApiInfo
                {
                    Title = ApiInfo.Name,
                    Version = ApiInfo.Version,
                    Description = ApiInfo.Description,
                    Contact = new OpenApiContact
                    {
                        Name = ApiInfo.Name,
                        Url = new Uri(ApiInfo.Url)
                    },
                });
                c.EnableAnnotations();
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        private void AuthenticationConfigureService(IServiceCollection services)
        {
             var key = Encoding.ASCII.GetBytes(ConfigurationSettings.Secret);
            services
                .AddAuthentication(p =>
                {
                    p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(p =>
                {
                    p.RequireHttpsMetadata = false;
                    p.SaveToken = true;
                    p.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}
