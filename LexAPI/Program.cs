
using Microsoft.Extensions.Configuration;

namespace LexAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Caching.InitialiseCache();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //The following is restricting POST to particular IP address, but GET should be open to the world.
            var allowedIps = builder.Configuration.GetSection("AllowedIPs").Get<string[]>() ?? new[] { "127.0.0.1" };//See appsettings.json. It only allows local IP 127.0.0.1 out of the box
            app.UseMiddleware<IPFilterMiddleware>(allowedIps);

            app.MapControllers();

            

            app.Run();
        }
    }
}