
using Microsoft.EntityFrameworkCore;
using TechPulse.BL.Mapping;
using TechPulse.BL.Service.Implementation;
using TechPulse.BL.Service.Interface;
using TechPulse.DAL.Context;
using TechPulse.DAL.Repository;

namespace TechPulse.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Database 
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Add Services

            builder.Services.AddScoped<IPostRepo, PostRepo>();
            builder.Services.AddScoped<IPostService, PostService>();

            builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            //CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseCors("AllowAngular");

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append(
                        "Cache-Control", "public,max-age=86400");
                }
            });

            app.UseAuthorization();


            app.MapControllers();
            app.Run();

        }
    }
}
