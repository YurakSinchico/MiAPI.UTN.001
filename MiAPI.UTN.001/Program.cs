using MiAPI.UTN._001.Data;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MiAPI.UTN._001
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MiAPIUTN_001Context>(options =>


            //para volver a usar postgres despues de haber usadao las otras base de datos y se cambia lo mismo en el options
            //para regresar a cualquier base de datos como mariadb, o sqlserver
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"))

); 
            //postgres
            //    options.UseNpgsql(builder.Configuration.GetConnectionString("MiAPIUTN_001Context") ?? throw new InvalidOperationException("Connection string 'MiAPIUTN_001Context' not found.")));


            // maria db
            //         builder.Services.AddDbContext<MiAPIUTN_001Context>(options =>
            //         options.UseMySql(
            //         builder.Configuration.GetConnectionString("MariaDB"),
            //         ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDB")),
            //         mysqlOptions => mysqlOptions.EnableRetryOnFailure() 
            //         )


            //);
            //hasta aqui maria db



            //sqlserver
            //builder.Services.AddDbContext<MiAPIUTN_001Context>(options =>

            //options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))

            //);

            //hasta aqui el sql server




            // Add services to the container.

            builder.Services.AddControllers()
                .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //añadi esto
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //comentamos esto app.MapOpenApi();


                //añadir esto para ver el swager
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
