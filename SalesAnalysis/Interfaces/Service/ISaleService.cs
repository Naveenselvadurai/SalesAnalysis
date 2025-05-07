
namespace SalesAnalysis.Interfaces.Services
{
    public interface ISaleService
    {
        Task<bool> LoadCsvDataAsync(IFormFile file);
        Task<decimal> CalculateTotalRevenueAsync(DateTime startDate, DateTime endDate);
    }
}