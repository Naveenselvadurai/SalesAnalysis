using MongoDB.Driver;
using SalesAnalysis.Interfaces.DataAccess;
using SalesAnalysis.Models.Entities;
using Microsoft.Extensions.Options;
using SalesAnalysis.Models;

namespace SalesAnalysis.DataAccess
{
    public class SaleDataAccess : ISaleDataAccess
    {
        private readonly IMongoCollection<SalesDAO> _collection;
        private readonly ILogger<SaleDataAccess> _logger;

        public SaleDataAccess(IOptions<SaleDatabaseSettings> settings, ILogger<SaleDataAccess> logger)
        {
            var config = settings.Value;
            var client = new MongoClient(config.ConnectionString);
            var database = client.GetDatabase(config.DatabaseName);
            _collection = database.GetCollection<SalesDAO>(config.SalesCollectionName);
            _logger = logger;
        }

        public async Task InsertManyAsync(IEnumerable<SalesDAO> sales)
        {
            try
            {
                await _collection.InsertManyAsync(sales);
                _logger.LogInformation("Inserted {Count} records", sales.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "InsertManyAsync failed");
                throw;
            }
        }

        public async Task<IEnumerable<SalesDAO>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var filter = Builders<SalesDAO>.Filter.Gte(x => x.DateOfSale, startDate) &
                             Builders<SalesDAO>.Filter.Lte(x => x.DateOfSale, endDate);
                return await _collection.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetSalesByDateRangeAsync failed");
                throw;
            }
        }
    }
}