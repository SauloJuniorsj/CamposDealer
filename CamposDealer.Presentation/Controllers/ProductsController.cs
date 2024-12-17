using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Implementations;
using CamposDealer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Index")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Index()
        {
            var clients = await _productService.GetAll(string.Empty);
            return View(clients);
        }

        /// <summary>
        /// Retorna uma coleção de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll(string? query = null)
        {
            var clients = await _productService.GetAll(query);
            return Ok(clients);
        }

        /// <summary>
        /// Retorna um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("Create")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return View("Create", new CreateProductInputModel());
        }

        [HttpGet("Edit")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> Edit(int id)
        {
            var client = await _productService.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            var updateClient = new UpdateProductInputModel
            {
                Id = client.Id,
                Description = client.Description,
                ProductValue = client.ProductValue
            };

            return View("Update", updateClient);
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="createProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateProductInputModel createProduct)
        {
            if (ModelState.IsValid)
            {
                var id = await _productService.Create(createProduct);
                return RedirectToAction(nameof(Index));
            }

            return View(createProduct);
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="updateProduct"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateProductInputModel updateProduct)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(updateProduct);
                return RedirectToAction(nameof(Index));

            }
            return View(updateProduct);
        }
        /// <summary>
        /// Deleta um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
