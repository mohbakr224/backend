
using Assignment_17.Data;
using Assignment_17.Repository;
using Assignment_17.Repository.interfaces;
using Assignment_17.Services;
using Assignment_17.Services.Interfaces;
using Assignment_17.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Assignment_17
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskRequestValidator>();
            builder.Services.AddControllers();
            builder.Services.AddSingleton<TaskData>();

            builder.Services.AddScoped<ITaskrepo, Taskrepo>();

            builder.Services.AddScoped<ITaskServices, TaskServices>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
