using Microsoft.AspNetCore.Mvc;
using QuickCompare.Application.Dto;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ComparacaoController : ControllerBase
{
    private readonly CompararCelularesUseCase _useCase;

    public ComparacaoController(CompararCelularesUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("celular/{id1:int}/{id2:int}")]
    public async Task<IActionResult> CompararCelulares(int id1, int id2)
    {
        var resultado = await _useCase.ExecutarCelularAsync(id1, id2);
        return Ok(new { Resultado = resultado });
    }

    [HttpGet("notebook/{id1:int}/{id2:int}")]
    public async Task<IActionResult> CompararNotebooks(int id1, int id2)
    {
        var resultado = await _useCase.ExecutarNotebookAsync(id1, id2);
        return Ok(new { Resultado = resultado });
    }
}
