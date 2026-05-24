namespace TopTechApi.Models
{
    public class Tecnico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;

        public List<OrdemServico> OrdensServico { get; set; } = new();
    }
}