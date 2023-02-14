using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.Repositories;
using Tasks.Repositories.Interfaces;

namespace Tasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<TasksDbContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
                );

            builder.Services.AddScoped<IUser, UserRepositorie>();
            builder.Services.AddScoped<ITask, TaskRepositorie>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}