using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Interfaces;

public class CompararCelularesUseCase
{
    private readonly ICelularRepository _repoCelular;
    private readonly ICompararCelulares _comparadorCelular;
    private readonly INotebookRepository _repoNotebook;
    private readonly ICompararNotebooks _comparadorNotebook;

    public CompararCelularesUseCase(
        ICelularRepository repoCelular,
        ICompararCelulares comparadorCelular,
        INotebookRepository repoNotebook,
        ICompararNotebooks comparadorNotebook)
    {
        _repoCelular = repoCelular;
        _comparadorCelular = comparadorCelular;
        _repoNotebook = repoNotebook;
        _comparadorNotebook = comparadorNotebook;
    }

    public async Task<ComparacaoResultadosDto> ExecutarCelularAsync(int id1, int id2)
    {
        var celularA = await _repoCelular.ObterCelularPorId(id1);
        var celularB = await _repoCelular.ObterCelularPorId(id2);

        if (celularA == null || celularB == null)
        {
            return new ComparacaoResultadosDto
            {
                Resultado = "Um ou ambos os celulares não foram encontrados."
            };
        }

        return _comparadorCelular.Comparar(celularA, celularB);
    }

    public async Task<ComparacaoResultadosDto> ExecutarNotebookAsync(int id1, int id2)
    {
        var notebookA = await _repoNotebook.BuscarNotebookId(id1);
        var notebookB = await _repoNotebook.BuscarNotebookId(id2);

        if (notebookA == null || notebookB == null)
        {
            return new ComparacaoResultadosDto
            {
                Resultado = "Um ou ambos os notebooks não foram encontrados."
            };
        }

        return _comparadorNotebook.CompararNotebook(notebookA, notebookB);
    }
}
