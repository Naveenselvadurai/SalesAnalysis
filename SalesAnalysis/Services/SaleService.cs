using SalesAnalysis.Interfaces.DataAccess;
using SalesAnalysis.Interfaces.Services;
using SalesAnalysis.Utils;

namespace SalesAnalysis.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleDataAccess _dataAccess;
        private readonly ILogger<SaleService> _logger;

        public SaleService(ISaleDataAccess dataAccess, ILogger<SaleService> logger)
        {
            _dataAccess = dataAccess;
            _logger = logger;
        }

        public async Task<bool> LoadCsvDataAsync(IFormFile file)
        {
            try
            {
                var sales = await CsvLoader.ParseCsvAsync(file);
                await _dataAccess.InsertManyAsync(sales);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LoadCsvDataAsync failed");
                return false;
            }
        }

        public async Task<decimal> CalculateTotalRevenueAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var sales = await _dataAccess.GetSalesByDateRangeAsync(startDate, endDate);
                return sales.Sum(s => (s.UnitPrice * s.QuantitySold) - s.Discount + s.ShippingCost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CalculateTotalRevenueAsync failed");
                return 0;
            }
        }
    }
}
