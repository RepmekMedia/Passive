using Microsoft.AspNetCore.Builder;

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
            services.AddLogging();

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
