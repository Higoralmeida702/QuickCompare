using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Services
{
    public class CompararNotebooksService : ICompararNotebooks
    {
        public ComparacaoResultadosDto CompararNotebook(NotebookEntity notebookA, NotebookEntity notebookB)
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
                        detalhes.Add($"{notebookA.Modelo} vence em {nome}: {a}{unidade} vs {b}{unidade}");
                    }
                    else if (b > a)
                    {
                        pontosB++;
                        detalhes.Add($"{notebookB.Modelo} vence em {nome}: {b}{unidade} vs {a}{unidade}");
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
                    detalhes.Add($"{notebookA.Modelo} possui {nome}");
                }
                else if (!valorA && valorB)
                {
                    pontosB++;
                    detalhes.Add($"{notebookB.Modelo} possui {nome}");
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

            Comparar("Peso", notebookA.Peso, notebookB.Peso, "g");
            Comparar("Capacidade de bateria", notebookA.Mah, notebookB.Mah, "mAh");
            Comparar("Duração de bateria", notebookA.DuracaoBateriaAproximada, notebookB.DuracaoBateriaAproximada, "h");
            Comparar("Memória RAM", notebookA.MemoriaRam, notebookB.MemoriaRam, "GB");
            Comparar("Armazenamento", notebookA.CapacidadeArmazenamento, notebookB.CapacidadeArmazenamento, "GB");

            if (notebookA.Tela != null && notebookB.Tela != null)
            {
                Comparar("Resolução de tela", (int)notebookA.Tela.QualidadeResolucao, (int)notebookB.Tela.QualidadeResolucao);
                Comparar("Taxa de atualização", (int)notebookA.Tela.AtualizacaoTela, (int)notebookB.Tela.AtualizacaoTela, "Hz");
            }

            CompararBool("Webcam", notebookA.WebCam, notebookB.WebCam);

            string resultado;
            if (pontosA > pontosB) resultado = $"{notebookA.Modelo} é superior.";
            else if (pontosB > pontosA) resultado = $"{notebookB.Modelo} é superior.";
            else resultado = "Os notebooks são equivalentes.";

            return new ComparacaoResultadosDto
            {
                Resultado = resultado,
                Pontos = detalhes
            };
        }
    }
}
