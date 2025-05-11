namespace QuickCompare.Application.Dto
{
    public class ComparacaoResultadosDto
    {
        public string Resultado { get; set; } = string.Empty;
        public List<string> Pontos { get; set; } = new();
    }
}