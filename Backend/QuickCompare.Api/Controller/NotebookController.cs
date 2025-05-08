using Microsoft.AspNetCore.Mvc;
using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotebookController : ControllerBase
    {
        private readonly INotebookService _service;

        public NotebookController(INotebookService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<NotebookEntity>> AdicionarNotebook([FromBody] NotebookDto notebookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _service.AdicionarNotebook(notebookDto);
            return Ok(created);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotebookEntity>> BuscarNotebookPorId(int id)
        {
            try
            {
                var notebook = await _service.BuscarNotebookId(id);
                if (notebook == null)
                {
                    return NotFound(new { message = "Notebook não encontrado." });
                }

                return Ok(notebook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar notebook.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirNotebook(int id)
        {
            try
            {
                var notebookDeletado = await _service.ExcluirNotebook(id);

                if (notebookDeletado == null)
                {
                    return NotFound(new { message = "Notebook não encontrado." });
                }

                return Ok(new { message = "Notebook deletado com sucesso.", notebook = notebookDeletado });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao tentar deletar notebook.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarNotebook(int id, [FromBody] NotebookDto notebookDto)
        {
            if (notebookDto == null)
                return BadRequest("Dados inválidos.");

            try
            {
                var notebookAtualizado = await _service.AtualizarNotebook(id, notebookDto);

                if (notebookAtualizado == null)
                {
                    return NotFound(new { message = "Notebook não encontrado." });
                }

                return Ok(notebookAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao atualizar notebook.", error = ex.Message });
            }
        }
    }
}
