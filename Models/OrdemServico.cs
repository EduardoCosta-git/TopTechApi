namespace TopTechApi.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public string ProblemaRelatado { get; set; } = string.Empty;
        public string Status { get; set; } = "Aberta";

        public int ComputadorId { get; set; }
        public Computador? Computador { get; set; }

        public int TecnicoId { get; set; }
        public Tecnico? Tecnico { get; set; }

        public List<Peca> Pecas { get; set; } = new();
        public List<Servico> Servicos { get; set; } = new(); 
        public List<Pagamento> Pagamentos { get; set; } = new(); 
    }
}