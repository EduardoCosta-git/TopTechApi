namespace TopTechApi.Models
{
    public class Computador
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public List<OrdemServico> OrdensServico { get; set; } = new();
    }
}
