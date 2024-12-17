using CamposDealer.Application.InputModels;
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
        /// <summary>
        /// Retorna uma coleção de projetos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll(string? query = null)
        {
            var projects = await _productService.GetAll(query);
            return Ok(projects);
        }

        /// <summary>
        /// Retorna um projeto
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

        /// <summary>
        /// Cria um novo projeto
        /// </summary>
        /// <param name="createProject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductInputModel createProject)
        {
            var Id = await _productService.Create(createProject);

            return Ok(Id);
        }

        /// <summary>
        /// Deleta um projeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
