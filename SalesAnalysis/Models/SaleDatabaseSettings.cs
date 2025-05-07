namespace SalesAnalysis.Models
{
    public class SaleDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string SalesCollectionName { get; set; } = null!;
    }
}
