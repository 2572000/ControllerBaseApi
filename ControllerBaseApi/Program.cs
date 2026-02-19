using ControllerBaseApi.Data;
using System.Text.Json.Serialization;

namespace ControllerBaseApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });
            builder.Services.AddSingleton<ProductRepository>();


            var app = builder.Build();


            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
