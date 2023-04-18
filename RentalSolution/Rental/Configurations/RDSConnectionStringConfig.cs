namespace Rental.Configurations;

public class RDSConnectionStringConfig
{
    public string ConnectionString { get; set; }

    public RDSConnectionStringConfig(string connectionString)
    {
        ConnectionString = connectionString;
    }
}