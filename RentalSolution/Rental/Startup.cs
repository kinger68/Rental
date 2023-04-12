using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Rental;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

        // Setup Json serialization preferences globally
        JsonConvert.DefaultSettings =
            () => new JsonSerializerSettings
            {
                Converters = {
                    new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() }
                },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        
    }
}