using CamposDealer.Application.Services.Implementations;
using CamposDealer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataLoaderController : Controller
    {
        private readonly IDataLoaderService _dataLoaderService;

        public DataLoaderController(IDataLoaderService dataLoaderService)
        {
            _dataLoaderService = dataLoaderService;
        }

        [HttpPost("load-data")]
        public async Task<IActionResult> LoadData()
        {
            await _dataLoaderService.LoadDataAsync();
            return Ok("Dados carregados com sucesso!");
        }
    }
}
