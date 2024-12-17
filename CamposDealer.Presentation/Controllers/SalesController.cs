using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Implementations;
using CamposDealer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : Controller
    {
        private readonly ISaleService _salesService;
        public SalesController(ISaleService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet("Index")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Index()
        {
            var sales = await _salesService.GetAll(string.Empty);
            return View(sales);
        }

        /// <summary>
        /// Retorna uma coleção de projetos
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll(string? query = null)
        {
            var sales = await _salesService.GetAll(query);
            return Ok(sales);
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

        [HttpGet("Create")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return View("Create", new CreateSaleInputModel());
        }

        /// <summary>
        /// Edita uma venda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Edit")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> Edit(int id)
        {
            var client = await _salesService.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            var updateClient = new UpdateSaleInputModel
            {
                Id = client.Id,
                IdClient = client.IdClient,
                IdProduct = client.IdProduct,
                SalesQtd = client.SalesQtd,
                ValueUnitValue = client.ValueUnitValue,
                TotalSaleValue = client.TotalSaleValue
            };

            return View("Update", updateClient);
        }

        /// <summary>
        /// Cria uma nova venda
        /// </summary>
        /// <param name="saleModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateSaleInputModel createSale)
        {
            if (ModelState.IsValid)
            {
                var id = await _salesService.Create(createSale);
                return RedirectToAction(nameof(Index));
            }

            return View(createSale);
        }

        /// <summary>
        /// Atualiza uma venda
        /// </summary>
        /// <param name="updateSale"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateSaleInputModel updateSale)
        {
            if (ModelState.IsValid)
            {
                await _salesService.Update(updateSale);
                return RedirectToAction(nameof(Index));

            }
            return View(updateSale);
        }
        /// <summary>
        /// Deleta uma venda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _salesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
