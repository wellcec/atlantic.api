using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RestEase;
using Serilog;
using StackExchange.Redis;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Facades.Strategies.ExceptionHandlingStrategies;
using Atlantic.Api.Models.Mapper;
using Atlantic.Api.Models.UI;
using Atlantic.Api.Services;
using Atlantic.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Data.EcommerceDataContext.Repositories;
using Atlantic.Api.Facades.Core;
using Atlantic.Api.Facades.Validators;
using Amazon.S3;

namespace Atlantic.Api.Facades.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        private const string SETTINGS_SECTION = "Settings";

        /// <summary>
        /// Registers project's specific services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSingletons(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(SETTINGS_SECTION).Get<ApiSettings>();

            // Dependency injection
            services.AddSingleton(settings)
                    .AddSingleton(settings.SwaggerCredentials)
                    .AddSingleton<IRedisService, RedisService>()
                    .AddSingleton<IAmazonS3Service, AmazonS3Service>()
                    .AddSingleton<IVariationsRepository, VariationsRepository>()
                    .AddSingleton<ICategoriesRepository, CategoriesRepository>()
                    .AddSingleton<IImagesRepository, ImagesRepository>()
                    .AddSingleton<IProductsRepository, ProductsRepository>();

            services.AddScoped<CommonDependenciesFacade>()
                    .AddScoped<IValidatorHelper, ValidatorHelper>()
                    .AddScoped<IWarnMeFacade, WarnMeFacade>()
                    .AddScoped<IProductsFacade, ProductsFacade>()
                    .AddScoped<IVariationsFacade, VariationsFacade>()
                    .AddScoped<ICategoriesFacade, CategoriesFacade>()
                    .AddScoped<IImagesFacade, ImagesFacade>()
                    .AddScoped<IWarnMeService, WarnMeService>();

            services.AddHttpClient();

            //var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));

            //services.AddSingleton<IConnectionMultiplexer>(multiplexer);

            //Mapper configurations
            var mapperConfig = new MapperConfiguration(m => m.AddProfiles(
                new List<Profile>()
                {
                    new AutoMapperProfile()
                }));

            services.AddSingleton(mapperConfig.CreateMapper());

            services.AddWebServices(settings);

            services.AddSingleton(provider =>
            {
                var logger = provider.GetService<ILogger>();
                return new Dictionary<Type, ExceptionHandlingStrategy>
                {
                    { typeof(ApiException), new ApiExceptionHandlingStrategy(logger) },
                    { typeof(NotImplementedException), new NotImplementedExceptionHandlingStrategy(logger) }
                };
            });

            // SERILOG settings
            services.AddSingleton<ILogger>(new LoggerConfiguration()
                     .MinimumLevel.Debug()
                     .WriteTo.Console()
                     .CreateLogger());
        }

        private static IServiceCollection AddWebServices(this IServiceCollection services, ApiSettings settings)
        {
            // TODO Add connection to another API
            services.AddSingleton<IAmazonS3>(sp =>
            {
                var config = new AmazonS3Config
                {
                    RegionEndpoint = Amazon.RegionEndpoint.USEast1,
                    ServiceURL = settings.AmazonSettings.BaseUrl,
                    ForcePathStyle = true
                };

                return new AmazonS3Client(settings.AmazonSettings.KeyId, settings.AmazonSettings.AccessKey, config);
            });

            return services;
        }

        public static void AddMongoContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoClient>(ServiceProvider =>
            {
                var settings = ServiceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });
        }
    }
}
