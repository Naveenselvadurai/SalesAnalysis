using CsvHelper;
using CsvHelper.Configuration;
using SalesAnalysis.Models.Entities;
using System.Globalization;

namespace SalesAnalysis.Utils
{
    public static class CsvLoader
    {
        public static async Task<List<SalesDAO>> ParseCsvAsync(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            });
            return await Task.Run(() => csv.GetRecords<SalesDAO>().ToList());
        }
    }
}