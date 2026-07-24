using Asp.Versioning;
using Assignment_11.Repositry;
using Assignment_11.Serivces;
using Microsoft.OpenApi;
using System.Reflection;

namespace Assignment_11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add controllers
            builder.Services.AddControllers();

            // RFC 7807 Problem Details
            builder.Services.AddProblemDetails();

            // Dependency Injection
            builder.Services.AddScoped<ProductServices>();
            builder.Services.AddScoped<ProductsRepo>();

            // API Versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            }).AddApiExplorer(options =>
            {
                options.SubstituteApiVersionInUrl = true;
            });

            // Swagger
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Product API",
                    Version = "v1",
                    Description = "API for managing products - Version 1"
                });

                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Product API",
                    Version = "v2",
                    Description = "API for managing products - Version 2"
                });

                // XML Comments
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Product API V1");
                    c.SwaggerEndpoint("v2/swagger.json", "Product API V2");
                });
            }

            app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}