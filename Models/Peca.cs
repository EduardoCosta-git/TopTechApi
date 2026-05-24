namespace TopTechApi.Models
{
    public class Peca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal PrecoBase { get; set; }

        public int CategoriaPecaId { get; set; }
        public CategoriaPeca? Categoria { get; set; }

        public List<OrdemServico> OrdensServico { get; set; } = new();
    }
}
