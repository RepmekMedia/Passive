using Passive.API.Extensions;

namespace Passive.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; init; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddDBContexts(Configuration);

            services.AddEFSecondLevelCache(Configuration);

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(config =>
            {
                config.IgnoreObsoleteActions();
                config.IgnoreObsoleteProperties();
            });

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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Passive");
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

        private static async Task SkipFavicon(HttpContext context, Func<Task> next)
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
