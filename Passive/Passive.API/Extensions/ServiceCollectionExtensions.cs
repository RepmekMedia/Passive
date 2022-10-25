﻿using EFCoreSecondLevelCacheInterceptor;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using MessagePack;
using Microsoft.EntityFrameworkCore;
using Passive.API.DBContexts;
using Passive.API.Formatters;

namespace Passive.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDBContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccessContext>(options =>
            {
                // TODO: ConnectionString to Docker PostgresSQL DB and the PostgresSQL Version
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
                options.EnableSensitiveDataLogging(true);
            });

            return services;
        }

        public static IServiceCollection AddEFCache(this IServiceCollection services, IConfiguration configuration)
        {
            const string cacheProviderName = "redisCache";
            const string serializerName = "messagePack";
            services.AddEFSecondLevelCache(options =>
            {
                options.UseEasyCachingCoreProvider(cacheProviderName, isHybridCache: false).DisableLogging(false).UseCacheKeyPrefix("EF_");
                options.CacheAllQueries(CacheExpirationMode.Absolute, TimeSpan.FromMinutes(5));
            });

            services.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Configuration = configuration.GetConnectionString("RedisCache");
                    config.DBConfig.AllowAdmin = true;
                    config.EnableLogging = true;
                    config.SerializerName = serializerName;
                    config.DBConfig.SyncTimeout = 10000;
                    config.DBConfig.AsyncTimeout = 10000;
                    config.DBConfig.ConnectionTimeout = 10000;
                }, cacheProviderName)
                .WithMessagePack(config =>
                {
                    config.EnableCustomResolver = true;
                    config.CustomResolvers = CompositeResolver.Create(
                    new IMessagePackFormatter[]
                    {
                                               DBNullFormatter.Instance,
                    },
                    new IFormatterResolver[]
                    {
                                              NativeDateTimeResolver.Instance,
                                              ContractlessStandardResolver.Instance,
                                              StandardResolverAllowPrivate.Instance,
                    });
                }, serializerName);
            });
            return services;
        }
    }
}
