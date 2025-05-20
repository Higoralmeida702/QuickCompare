using QuickCompare.Application.Common;
using QuickCompare.Application.Dto;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Interfaces
{
    public interface ICelularService
    {
        Task<Resposta<CelularEntity>> AdicionarCelular(CelularDto celularDto);
        Task<Resposta<CelularEntity>> ObterCelularPorId(int id);
        Task<Resposta<CelularEntity>> ExcluirCelular(int id);
        Task<Resposta<List<CelularEntity>>> ObterTodosCelulares();
        Task<Resposta<CelularDto>> AtualizarCelular (int id, CelularDto celularDto);
    }
}