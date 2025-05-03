using QuickCompare.Domain.Entity;

namespace QuickCompare.Domain.Interfaces
{
    public interface ICelularRepository
    {
      Task<CelularEntity> AdicionarCelular (CelularEntity celular);
      Task<CelularEntity> ObterCelularPorId (int id);

    }
}