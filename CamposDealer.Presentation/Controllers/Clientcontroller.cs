using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Clientcontroller : ControllerBase
    {
        private readonly IClientService _clientService;
        public Clientcontroller(IClientService clientService)
        {
            _clientService = clientService;
        }
        /// <summary>
        /// Retorna uma coleção de clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var projects = await _clientService.GetAll();
            return Ok(projects);
        }

        /// <summary>
        /// Retorna um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _clientService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <param name="createClient"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientInputModel createClient)
        {
            var Id = await _clientService.Create(createClient);

            return Ok(Id);
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.Delete(id);
            return Ok();
        }
    }
}
