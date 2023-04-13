using Microsoft.EntityFrameworkCore;
using Rental.Data.DataModels;
namespace Rental.Data;

public class RentalPropertyContext : DbContext
{
    private readonly string connectionString;

    public RentalPropertyContext(string connectionString)
    {
        this.connectionString = connectionString;
        
        // Hard coding connection string for testing until I add pass connection string to DI
        this.connectionString = "server=127.0.0.1;uid=root;pwd=;database=Rental";
    }
    
    public DbSet<RentalPropertyDto> RentalProperties { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(connectionString);
    }
}