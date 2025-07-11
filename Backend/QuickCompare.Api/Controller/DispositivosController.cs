using Microsoft.AspNetCore.Mvc;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickCompare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivosController : ControllerBase
    {
        private readonly ICompararDispositivosService _compararDispositivosService;

        public DispositivosController(ICompararDispositivosService compararDispositivosService)
        {
            _compararDispositivosService = compararDispositivosService;
        }

        [HttpGet("celulares/buscar")]
        public async Task<ActionResult<List<CelularEntity>>> BuscarCelulares([FromQuery] string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return BadRequest("Termo de busca obrigatório.");

            var celulares = await _compararDispositivosService.BuscarCelularPorMarcaOuModelo(termo);
            return Ok(celulares);
        }

        [HttpGet("notebooks/buscar")]
        public async Task<ActionResult<List<NotebookEntity>>> BuscarNotebooks([FromQuery] string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return BadRequest("Termo de busca obrigatório.");

            var notebooks = await _compararDispositivosService.BuscarNotebookPorMarcaOuModelo(termo);
            return Ok(notebooks);
        }
    }
}
