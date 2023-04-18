
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Rental.Configurations;
using Rental.Data;
using Rental.Services;

namespace Rental
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Domain Services - Add the services which support all the domain objects
            // (RentalPropeties and Renters)
            builder.Services.AddScoped<IRentalPropertyService, RentalPropertyService>();
            
            // Add Entity Framework - transient so that DbContexts are not shared between operations
            builder.Services.AddDbContext<RentalPropertyContext>(ServiceLifetime.Transient);
            builder.Services.AddDbContext<CityContext>(ServiceLifetime.Transient);
            
            // Configure RDS Connection String for Postgres
            string connectionString = "server=127.0.0.1;uid=root;pwd=;database=Rental";
            builder.Services.AddSingleton(serviceProvider => new RDSConnectionStringConfig(connectionString));

            // Persistence Registration
            builder.Services.AddScoped<IRentalPropertyRepository, EfRentalRepository>();
            
            // Setup Json serialization preferences globally
            JsonConvert.DefaultSettings =
                () => new JsonSerializerSettings
                {
                    Converters = {
                        new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() }
                    },
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
            
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

            return 0;
        }
    }
}
