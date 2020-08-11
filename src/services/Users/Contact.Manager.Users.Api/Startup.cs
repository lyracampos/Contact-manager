using System;
using System.IO;
using System.Reflection;
using Contact.Manager.Users.Api.Behaviors;
using Contact.Manager.Users.Domain.Repositories;
using Contact.Manager.Users.Infrastructure.Context;
using Contact.Manager.Users.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Contact.Manager.Users.Api
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
            
            var assembly = AppDomain.CurrentDomain.Load("Contact.Manager.Users.Application");
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));
            services.AddValidatorsFromAssembly(assembly);


            services.AddTransient<IDbContext, DbContext>();
            services.AddTransient<IUserRepository, UserRepository>();

            SwaggerConfigureService(services);
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

            app.UseAuthorization();

            app.UseSwagger();

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
    }
}
