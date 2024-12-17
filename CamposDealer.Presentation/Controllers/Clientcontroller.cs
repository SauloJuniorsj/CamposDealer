using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("Index")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAll(string.Empty);
            return View(clients);
        }

        /// <summary>
        /// Retorna uma coleção de clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll(string? query = null)
        {
            var projects = await _clientService.GetAll(query);
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
            var client = await _clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpGet("Create")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return View("Create", new CreateClientInputModel());
        }

        [HttpGet("Edit")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> Edit(int id)
        {
            var client = await _clientService.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            var updateClient = new UpdateClientInputModel
            {
                Id = client.Id,
                Name = client.Name,
                City = client.City
            };

            return View("Update", updateClient);
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <param name="createClient"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateClientInputModel createClient)
        {
            if (ModelState.IsValid)
            {
                var id = await _clientService.Create(createClient);
                return RedirectToAction(nameof(Index));
            }

            return View(createClient);
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="updateClient"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateClientInputModel updateClient)
        {
            if (ModelState.IsValid)
            {
                await _clientService.Update(updateClient);
                return RedirectToAction(nameof(Index));

            }
            return View(updateClient);
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
