
using Microsoft.AspNetCore.Mvc;

namespace FormBindingInMinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            

            app.UseHttpsRedirection();

            app.MapGet("/", () =>
            {
                // Simple form with a checkbox and a submit button
                var html = """
                            <html>
                              <body>
                                <form action="/todo" method="POST">
                                  <input type="text" name="name" />
                                  <input type="submit" />
                                </form>
                              </body>
                            </html>
                           """;
                return Results.Content(html, "text/html");
            });

            // receive the checkbox as a boolean
            app.MapPost("/todo", ([FromForm] string name) => {
                
                return Results.Ok(name);
            
            }).DisableAntiforgery();

            app.Run();
        }
    }
}
