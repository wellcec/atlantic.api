using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Prometheus;

using Atlantic.Api.Facades.Extensions;
using Atlantic.Api.Middleware;
using Atlantic.Api.Models;
using Atlantic.Api.Models.Enums;
using Atlantic.Api.Models.UI;

namespace Atlantic.Api
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private const string SWAGGER_FILE_PATH = "./swagger/v1/swagger.json";
        private const string API_VERSION = "v1";
        private const string SETTINGS_SECTION = "Settings";
        private const string HEALTH_CHECK_ENDPOINT = "/health";
        private const string POLICY = "*";
        private const string SWAGGER_SECURITY_AUTHORIZATION_DESCRIPTION = "Enter 'Key' [space] and then your Token";
        private const string SWAGGER_SECURITY_BEARER = "Bearer";
        private const string SWAGGER_SECURITY_AUTHORIZATION = "Authorization";
        private const string SWAGGER_SECURITY_OAUTH2 = "oauth2";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(POLICY,
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddSingletons(Configuration);
            services.AddMongoContext(Configuration);
            // services.AddPostgresContext(Configuration);

            AddSwagger(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            var swaggerExhibition = Configuration.GetSection(SETTINGS_SECTION).Get<ApiSettings>().SwaggerCredentials.SwaggerExhibition;
            if (swaggerExhibition)
            {
                app.UseSwagger()
                       .UseSwaggerUI(c =>
                       {
                           c.RoutePrefix = string.Empty;
                           c.SwaggerEndpoint(SWAGGER_FILE_PATH, Constants.PROJECT_NAME + API_VERSION);
                       });
                
            }
            app.UseHttpsRedirection()
               .UseAuthentication()
               .UseRouting()
               .UseHttpMetrics()
               .UseCors(POLICY)
               .UseAuthorization()
               .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapMetrics();
                });
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(API_VERSION, new OpenApiInfo { Title = Constants.PROJECT_NAME, Version = API_VERSION });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + Constants.XML_EXTENSION;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition(SWAGGER_SECURITY_BEARER, new OpenApiSecurityScheme
                {
                    Description = SWAGGER_SECURITY_AUTHORIZATION_DESCRIPTION,
                    Name = SWAGGER_SECURITY_AUTHORIZATION,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = SWAGGER_SECURITY_BEARER
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = SWAGGER_SECURITY_BEARER
                                },
                                Scheme = SWAGGER_SECURITY_OAUTH2,
                                Name = SWAGGER_SECURITY_BEARER,
                                In = ParameterLocation.Header
                            },
                        new List<string>()
                    }
                });

                c.MapType<NotificationType>(() => new OpenApiSchema
                {
                    Type = "string",
                    Enum = Enum.GetNames(typeof(NotificationType)).Select(n => (IOpenApiAny)new OpenApiString(n)).ToList()
                });
            });
        }
    }
}
