using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;

public class CompararCelularService : ICompararCelulares
{
    public ComparacaoResultadosDto Comparar(CelularEntity celA, CelularEntity celB)
    {
        int pontosA = 0;
        int pontosB = 0;
        var vantagens = new List<string>();

        if (celA.Espessura < celB.Espessura) { pontosA++; vantagens.Add("A: Mais fino"); }
        else if (celB.Espessura < celA.Espessura) { pontosB++; vantagens.Add("B: Mais fino"); }

        if (celA.Peso < celB.Peso) { pontosA++; vantagens.Add("A: Mais leve"); }
        else if (celB.Peso < celA.Peso) { pontosB++; vantagens.Add("B: Mais leve"); }

        if (celA.Mah > celB.Mah) { pontosA++; vantagens.Add("A: Mais mAh"); }
        else if (celB.Mah > celA.Mah) { pontosB++; vantagens.Add("B: Mais mAh"); }

        if (celA.DuracaoBateriaAproximada > celB.DuracaoBateriaAproximada) { pontosA++; vantagens.Add("A: Maior duração de bateria"); }
        else if (celB.DuracaoBateriaAproximada > celA.DuracaoBateriaAproximada) { pontosB++; vantagens.Add("B: Maior duração de bateria"); }

        if (celA.ExpansaoMicroSd && !celB.ExpansaoMicroSd) { pontosA++; vantagens.Add("A: Expansão microSD"); }
        else if (!celA.ExpansaoMicroSd && celB.ExpansaoMicroSd) { pontosB++; vantagens.Add("B: Expansão microSD"); }

        if (celA.DualSim && !celB.DualSim) { pontosA++; vantagens.Add("A: Dual SIM"); }
        else if (!celA.DualSim && celB.DualSim) { pontosB++; vantagens.Add("B: Dual SIM"); }

        if (celA.Has5G && !celB.Has5G) { pontosA++; vantagens.Add("A: Suporte a 5G"); }
        else if (!celA.Has5G && celB.Has5G) { pontosB++; vantagens.Add("B: Suporte a 5G"); }

        if (celA.ComprimentoCelular > celB.ComprimentoCelular) { pontosA++; vantagens.Add("A: Maior comprimento"); }
        else if (celB.ComprimentoCelular > celA.ComprimentoCelular) { pontosB++; vantagens.Add("B: Maior comprimento"); }

        if (celA.LarguraCelular > celB.LarguraCelular) { pontosA++; vantagens.Add("A: Maior largura"); }
        else if (celB.LarguraCelular > celA.LarguraCelular) { pontosB++; vantagens.Add("B: Maior largura"); }

        if (celA.CapacidadeArmazenamento > celB.CapacidadeArmazenamento) { pontosA++; vantagens.Add("A: Mais armazenamento"); }
        else if (celB.CapacidadeArmazenamento > celA.CapacidadeArmazenamento) { pontosB++; vantagens.Add("B: Mais armazenamento"); }

        if (celA.MemoriaRam > celB.MemoriaRam) { pontosA++; vantagens.Add("A: Mais memória RAM"); }
        else if (celB.MemoriaRam > celA.MemoriaRam) { pontosB++; vantagens.Add("B: Mais memória RAM"); }

        if (celA.TipoAparelho > celB.TipoAparelho) { pontosA++; vantagens.Add("A: Tipo de aparelho superior"); }
        else if (celB.TipoAparelho > celA.TipoAparelho) { pontosB++; vantagens.Add("B: Tipo de aparelho superior"); }

        string resultado;
        if (pontosA > pontosB) resultado = "O celular A é superior.";
        else if (pontosB > pontosA) resultado = "O celular B é superior.";
        else resultado = "Os aparelhos são equivalentes.";

        return new ComparacaoResultadosDto
        {
            Resultado = resultado,
            Pontos = vantagens
        };
    }
}
