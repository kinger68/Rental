using Microsoft.EntityFrameworkCore;
using Rental.Configurations;
using Rental.Data.DataModels;
namespace Rental.Data;

public class RentalPropertyContext : DbContext
{
    private RDSConnectionStringConfig RdsConnectionStringConfig { get; }

    public RentalPropertyContext(RDSConnectionStringConfig connectionStringConfig)
    {
        this.RdsConnectionStringConfig = connectionStringConfig;
    }
    
    public DbSet<RentalPropertyDto> RentalProperties { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(RdsConnectionStringConfig.ConnectionString);
    }
}