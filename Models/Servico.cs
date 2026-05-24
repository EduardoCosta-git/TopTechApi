namespace TopTechApi.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }

        public List<OrdemServico> OrdensServico { get; set; } = new();
    }
}
