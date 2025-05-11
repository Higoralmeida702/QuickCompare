using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Interfaces;

public class CompararCelularesUseCase
{
    private readonly ICelularRepository _repo;
    private readonly ICompararCelulares _comparador;

    public CompararCelularesUseCase(ICelularRepository repo, ICompararCelulares comparador)
    {
        _repo = repo;
        _comparador = comparador;
    }

    public async Task<ComparacaoResultadosDto> ExecutarAsync(int id1, int id2)
    {
        var celularA = await _repo.ObterCelularPorId(id1);
        var celularB = await _repo.ObterCelularPorId(id2);

        if (celularA == null || celularB == null)
        {
            return new ComparacaoResultadosDto
            {
                Resultado = "Um ou ambos os celulares não foram encontrados."
            };
        }

        return _comparador.Comparar(celularA, celularB);
    }
}
