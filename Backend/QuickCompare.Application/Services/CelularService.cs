using QuickCompare.Application.Common;
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

        public async Task<Resposta<CelularEntity>> AdicionarCelular(CelularDto celularDto)
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

            var resultado = await _repository.AdicionarCelular(celular);

            return RespostaPadrao<CelularEntity>(celular, "Celular criado com sucesso");
        }

        public async Task<Resposta<CelularDto>> AtualizarCelular(int id, CelularDto celularDto)
        {
            var celularExistente = await _repository.ObterCelularPorId(id);

            if (celularExistente == null)
            {
                return RespostaPadrao<CelularDto>(null, "Celular não encontrado", false);
            }

            celularExistente.Update(
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

            await _repository.AtualizarCelular(id, celularExistente);

            var novaInformacoes = new CelularDto
            {
                Marca = celularExistente.Marca,
                Modelo = celularExistente.Modelo,
                Espessura = celularExistente.Espessura,
                Peso = celularExistente.Peso,
                Mah = celularExistente.Mah,
                DuracaoAproximadaBateria = celularExistente.DuracaoBateriaAproximada,
                CapacidadeArmazenamento = celularExistente.CapacidadeArmazenamento,
                MemoriaRam = celularExistente.MemoriaRam,
                TipoAparelho = celularExistente.TipoAparelho,
                Tela = celularExistente.Tela,
                ExpansaoMicroSd = celularExistente.ExpansaoMicroSd,
                DualSim = celularExistente.DualSim,
                Has5G = celularExistente.Has5G,
                ComprimentoCelular = celularExistente.ComprimentoCelular,
                LarguraCelular = celularExistente.LarguraCelular
            };
            return RespostaPadrao<CelularDto>(novaInformacoes, "Celular atualizado com sucesso");
        }


        public async Task<Resposta<CelularEntity>> ExcluirCelular(int id)
        {
            var celular = await _repository.ObterCelularPorId(id);
            if (celular == null)
            {
                return RespostaPadrao<CelularEntity>(null, "Celular não encontrado", false);
            }

            await _repository.ExcluirCelular(id);
            return RespostaPadrao<CelularEntity>(celular, "Celular removido com sucesso");
        }

        public async Task<Resposta<CelularEntity>> ObterCelularPorId(int id)
        {
            var celular = await _repository.ObterCelularPorId(id);

            if (celular == null)
            {
                return RespostaPadrao<CelularEntity>(null, "Celular não encontrado", false);
            }

            return RespostaPadrao<CelularEntity>(celular, "Celular encontrado com sucesso");
        }

        public async Task<Resposta<List<CelularEntity>>> ObterTodosCelulares()
        {
            var celulares = await _repository.ObterTodosCelulares();

            return RespostaPadrao<List<CelularEntity>>(celulares, "Lista de celulares obtida com sucesso");
        }

        private static Resposta<T> RespostaPadrao<T>(T? dados, string mensagem, bool status = true)
        {
            return new Resposta<T>
            {
                Dados = dados,
                Mensagem = mensagem,
                Status = status
            };

        }
    }
}