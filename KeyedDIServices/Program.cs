
using KeyedDIServices.Services;
using Microsoft.Extensions.Caching.Memory;

namespace KeyedDIServices
{
 

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Without keyed services, you could register all these services like this:
            // builder.Services.AddSingleton<INotificationService, SmsNotificationService>();
            // builder.Services.AddSingleton<INotificationService, EmailNotificationService>();
            // builder.Services.AddSingleton<INotificationService, PushNotificationService>();


            // when you inject INotificationService then you could retrieve only the last registered service (PushNotificationService) like this
            // But with keyed service you can inject anyone with key name
            builder.Services.AddKeyedSingleton<INotificationService, SmsNotificationService>("sms");
            builder.Services.AddKeyedSingleton<INotificationService, EmailNotificationService>("email");
            builder.Services.AddKeyedSingleton<INotificationService, PushNotificationService>("push");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGet("/sms", ([FromKeyedServices("sms")] INotificationService sms) =>
            {
                return Results.Ok(sms.Notify("Hello how are you from sms service?"));
            });

            // lly,

            app.MapGet("/email", ([FromKeyedServices("email")] INotificationService sms) =>
            {
                return Results.Ok(sms.Notify("Hello how are you from email service?"));
            });


            app.Run();
        }
    }
}
