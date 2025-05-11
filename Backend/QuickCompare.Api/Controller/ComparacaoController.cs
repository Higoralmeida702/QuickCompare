using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ComparacaoController : ControllerBase
{
    private readonly CompararCelularesUseCase _useCase;

    public ComparacaoController(CompararCelularesUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("{id1:int}/{id2:int}")]
    public async Task<IActionResult> Comparar(int id1, int id2)
    {
        var resultado = await _useCase.ExecutarAsync(id1, id2);
        return Ok(new { Resultado = resultado });
    }
}
