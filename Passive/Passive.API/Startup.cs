using EFCoreSecondLevelCacheInterceptor;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using Microsoft.EntityFrameworkCore;
using Passive.API.DBContexts;
using Passive.API.Formatters;

namespace Passive.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        public IConfiguration Configuration { get; init; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccessContext>(options =>
            {
                // TODO: ConnectionString to Docker MySQL DB and the MySQL Versionqw
                options.UseMySql("", new MySqlServerVersion(new Version(1, 1, 1)), m =>
                {
                    m.UseNewtonsoftJson(MySqlCommonJsonChangeTrackingOptions.FullHierarchyOptimizedFast);
                    m.EnableIndexOptimizedBooleanColumns();
                    m.EnableRetryOnFailure();
                });

                options.EnableSensitiveDataLogging(true);
            });

            const string cacheProviderName = "redisCache";
            services.AddEFSecondLevelCache(options =>
            {
                options.UseEasyCachingCoreProvider(cacheProviderName, isHybridCache: false).DisableLogging(false).UseCacheKeyPrefix("EF_");
                options.CacheAllQueries(CacheExpirationMode.Absolute, TimeSpan.FromMinutes(5));
            });

            services.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.AllowAdmin = true;
                    config.DBConfig.SyncTimeout = 10000;
                    config.DBConfig.AsyncTimeout = 10000;
                    // TODO: IP RedisDocker
                    config.DBConfig.Endpoints.Add(new EasyCaching.Core.Configurations.ServerEndPoint("127.0.0.1", 6379));
                    config.EnableLogging = true;
                    config.SerializerName = "Pack";
                    config.DBConfig.ConnectionTimeout = 10000;
                }, cacheProviderName)
                .WithMessagePack(so =>
                {
                    so.EnableCustomResolver = true;
                    so.CustomResolvers = CompositeResolver.Create(
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
                }, "Pack");
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
                });
            }

            app.Use(SkipFavicon);

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyMethod();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private async Task SkipFavicon(HttpContext context, Func<Task> next)
        {
            if (context.Request.Path.Value == "/favicon.ico")
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            await next.Invoke();
        }
    }
}
