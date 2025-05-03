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
            {
                Marca = celularDto.Marca,
                Modelo = celularDto.Modelo,
                Espessura = celularDto.Espessura,
                Peso = celularDto.Peso,
                mAh = celularDto.Mah,
                DuracaoBateriaAproximada = celularDto.DuracaoAproximadaBateria,
                CapacidadeArmazenamento = celularDto.CapacidadeArmazenamento,
                MemoriaRam = celularDto.MemoriaRam,
                TipoAparelho = celularDto.TipoAparelho,
                Tela = celularDto.Tela,
                ExpansaoMicroSd = celularDto.ExpansaoMicroSd,
                DualSim = celularDto.DualSim,
                Has5G = celularDto.Has5G,
                ComprimentoCelular = celularDto.ComprimentoCelular,
                LarguraCelular = celularDto.LarguraCelular,
            };

            return await _repository.AdicionarCelular(celular);
        }

        public async Task<CelularEntity> ObterCelularPorId(int id)
        {
            return await _repository.ObterCelularPorId(id);
        }
    }
}