using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _salesService;
        public SalesController(ISaleService salesService)
        {
            _salesService = salesService;
        }

        /// <summary>
        /// Retorna uma coleção de projetos
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// 
        [HttpGet("GetAll/{query}")]
        public async Task<ActionResult> GetAll(string query)
        {
            var projects = await _salesService.GetAll(query);
            return Ok(projects);
        }

        /// <summary>
        /// Retorna uma venda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var sale = await _salesService.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        /// <summary>
        /// Cria uma nova venda
        /// </summary>
        /// <param name="saleModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSaleInputModel saleModel)
        {
            var Id = await _salesService.Create(saleModel);

            return Ok(Id);
        }

        /// <summary>
        /// Deleta uma venda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _salesService.Delete(id);
            return Ok();
        }
    }
}
