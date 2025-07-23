using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;

public class CompararCelularService : ICompararCelulares
{
    public ComparacaoResultadosDto Comparar(CelularEntity celA, CelularEntity celB)
    {
        int pontosA = 0;
        int pontosB = 0;
        var detalhes = new List<string>();

        void Comparar(string nome, object valorA, object valorB, string unidade = "")
        {
            if (valorA == null || valorB == null) return;

            try
            {
                double a = Convert.ToDouble(valorA);
                double b = Convert.ToDouble(valorB);

                if (a > b)
                {
                    pontosA++;
                    detalhes.Add($"{celA.Modelo} vence em {nome}: {a}{unidade} vs {b}{unidade}");
                }
                else if (b > a)
                {
                    pontosB++;
                    detalhes.Add($"{celB.Modelo} vence em {nome}: {b}{unidade} vs {a}{unidade}");
                }
                else
                {
                    detalhes.Add($"Empate em {nome}: ambos com {a}{unidade}");
                }
            }
            catch
            {
                detalhes.Add($"Erro ao comparar {nome}: valores inválidos ({valorA}, {valorB})");
            }
        }

        void CompararBool(string nome, bool valorA, bool valorB)
        {
            if (valorA && !valorB)
            {
                pontosA++;
                detalhes.Add($"{celA.Modelo} possui {nome}");
            }
            else if (!valorA && valorB)
            {
                pontosB++;
                detalhes.Add($"{celB.Modelo} possui {nome}");
            }
            else if (valorA && valorB)
            {
                detalhes.Add($"Ambos possuem {nome}");
            }
            else
            {
                detalhes.Add($"Nenhum possui {nome}");
            }
        }

        Comparar("Espessura", celA.Espessura, celB.Espessura, "mm");
        Comparar("Peso", celA.Peso, celB.Peso, "g");
        Comparar("Bateria (mAh)", celA.Mah, celB.Mah, "mAh");
        Comparar("Duração de bateria", celA.DuracaoBateriaAproximada, celB.DuracaoBateriaAproximada, "h");
        Comparar("Comprimento", celA.ComprimentoCelular, celB.ComprimentoCelular, "mm");
        Comparar("Largura", celA.LarguraCelular, celB.LarguraCelular, "mm");
        Comparar("Armazenamento", celA.CapacidadeArmazenamento, celB.CapacidadeArmazenamento, "GB");
        Comparar("Memória RAM", celA.MemoriaRam, celB.MemoriaRam, "GB");
        Comparar("Tipo de aparelho", celA.TipoAparelho, celB.TipoAparelho);

        CompararBool("Expansão microSD", celA.ExpansaoMicroSd, celB.ExpansaoMicroSd);
        CompararBool("Dual SIM", celA.DualSim, celB.DualSim);
        CompararBool("5G", celA.Has5G, celB.Has5G);

        string resultado;
        if (pontosA > pontosB) resultado = $"{celA.Modelo} é superior.";
        else if (pontosB > pontosA) resultado = $"{celB.Modelo} é superior.";
        else resultado = "Os aparelhos são equivalentes.";

        return new ComparacaoResultadosDto
        {
            Resultado = resultado,
            Pontos = detalhes
        };
    }
}
