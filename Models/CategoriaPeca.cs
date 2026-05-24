namespace TopTechApi.Models
{
    public class CategoriaPeca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public List<Peca> Pecas { get; set; } = new();
    }
}
