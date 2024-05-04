
using ETHTPS.WSB.Services;

namespace ETHTPS.WSB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<L2Sweeper>(c =>
            {
                c.CreateAsyncScope();
                return new L2Sweeper(c.GetRequiredService<ILogger<L2Sweeper>>(), c.GetRequiredService<ILogger<L2Proxy>>(), c.GetRequiredService<HttpClient>());
            });
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
