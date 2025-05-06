using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;

namespace QuickCompare.Application.Services
{
    public class CelularService : ICelularService
    {

        private readonly ICelularRepository _repository;

        public CelularService(ICelularRepository repository)
        {
            _repository = repository;
        }

        public async Task<CelularEntity> AdicionarCelular(CelularDto celularDto)
        {
            var celular = new CelularEntity
            (
                celularDto.Marca,
                celularDto.Modelo,
                celularDto.Espessura,
                celularDto.Peso,
                celularDto.Mah,
                celularDto.DuracaoAproximadaBateria,
                celularDto.CapacidadeArmazenamento,
                celularDto.MemoriaRam,
                celularDto.TipoAparelho,
                celularDto.Tela,
                celularDto.ExpansaoMicroSd,
                celularDto.DualSim,
                celularDto.Has5G,
                celularDto.ComprimentoCelular,
                celularDto.LarguraCelular
            );

            return await _repository.AdicionarCelular(celular);
        }

        public async Task<CelularEntity> ExcluirCelular(int id)
        {
            var celular = await _repository.ObterCelularPorId(id);
            if (celular == null)
            {
                throw new Exception("Celular não encontrado");
            }

            await _repository.ExcluirCelular(id);
            return celular;
        }

        public async Task<CelularEntity> ObterCelularPorId(int id)
        {
            return await _repository.ObterCelularPorId(id);
        }

        public async Task<List<CelularEntity>> ObterTodosCelulares()
        {
            return await _repository.ObterTodosCelulares();
        }
    }
}