using Microsoft.EntityFrameworkCore;
using Rental.Configurations;
using Rental.Data.DataModels;

namespace Rental.Data;

public class CityContext : DbContext
{
    private RDSConnectionStringConfig RdsConnectionStringConfig { get; }

    public CityContext(RDSConnectionStringConfig rdsConnectionStringConfig)
    {
        RdsConnectionStringConfig = rdsConnectionStringConfig;
    }
    
    public DbSet<CityDto> Cities { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(RdsConnectionStringConfig.ConnectionString);
    }
}