using SalesAnalysis.Models.Entities;

namespace SalesAnalysis.Interfaces.DataAccess
{
    public interface ISaleDataAccess
    {
        Task InsertManyAsync(IEnumerable<SalesDAO> sales);
        Task<IEnumerable<SalesDAO>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}   