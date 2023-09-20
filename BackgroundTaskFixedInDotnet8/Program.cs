
namespace BackgroundTaskFixedInDotnet8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<HostOptions>(options =>
            {
                options.ServicesStartConcurrently = true;
                options.ServicesStopConcurrently = false;
            });

            builder.Services.AddHostedService<ExcecuteInBackground>();
            builder.Services.AddHostedService<ExecuteInBackgroundWithLifeCycle>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGet("/", () =>
            {
                return Results.Ok("Hello How are you!");
            });

            app.Run();
        }
    }
}
