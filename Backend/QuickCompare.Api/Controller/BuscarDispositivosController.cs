using Microsoft.AspNetCore.Mvc;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuscarDispositivosController : ControllerBase
    {
        private readonly IBuscarDispositivosService _buscarDispositivosService;

        public BuscarDispositivosController(IBuscarDispositivosService buscarDispositivosService)
        {
            _buscarDispositivosService = buscarDispositivosService;
        }

        [HttpGet("celulares/buscar")]
        public async Task<ActionResult<List<CelularEntity>>> BuscarCelulares([FromQuery] string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return BadRequest("Termo de busca obrigatório.");

            var celulares = await _buscarDispositivosService.BuscarCelularPorMarcaOuModelo(termo);
            return Ok(celulares);
        }

        [HttpGet("notebooks/buscar")]
        public async Task<ActionResult<List<NotebookEntity>>> BuscarNotebooks([FromQuery] string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return BadRequest("Termo de busca obrigatório.");

            var notebooks = await _buscarDispositivosService.BuscarNotebookPorMarcaOuModelo(termo);
            return Ok(notebooks);
        }
    }
}
