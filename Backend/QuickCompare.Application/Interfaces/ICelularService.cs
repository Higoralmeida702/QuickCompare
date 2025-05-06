using QuickCompare.Application.Dto;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Interfaces
{
    public interface ICelularService
    {
        Task<CelularEntity> AdicionarCelular(CelularDto celularDto);
        Task<CelularEntity> ObterCelularPorId(int id);
        Task<CelularEntity> ExcluirCelular(int id);
        Task<List<CelularEntity>> ObterTodosCelulares();
        Task<CelularDto> AtualizarCelular (int id, CelularDto celularDto);
    }
}