
using AuthChangeInDotNet8.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AuthChangeInDotNet8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

            builder.Services.AddAuthorizationBuilder();


            builder.Services.AddDbContext<ApplicationdbContext>(x=> x.UseSqlite("DataSource=app.db"));

            builder.Services.AddIdentityCore<MyUser>().AddEntityFrameworkStores<ApplicationdbContext>().AddApiEndpoints();

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

            app.MapIdentityApi<MyUser>();

            app.MapGet("/", (ClaimsPrincipal claims) =>
            {
                return $"Hello {claims.Identity!.Name}";
            }).RequireAuthorization();

            

            app.Run();
        }
    }
}
