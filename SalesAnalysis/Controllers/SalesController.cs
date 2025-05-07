using Microsoft.AspNetCore.Mvc;
using SalesAnalysis.Interfaces.Services;

namespace SalesAnalysis.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("upload-csv")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadCsv([FromForm] IFormFile File)
        {
            try
            {
                if (File == null || File.Length == 0)
                    return BadRequest("Invalid file.");

                var result = await _saleService.LoadCsvDataAsync(File);
                return result ? Ok("Data loaded successfully.") : StatusCode(500, "Data load failed.");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
    
        }

        [HttpGet("total-revenue")]
        public async Task<IActionResult> GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            var revenue = await _saleService.CalculateTotalRevenueAsync(startDate, endDate);
            return Ok(new { totalRevenue = revenue });
        }
    }
}
