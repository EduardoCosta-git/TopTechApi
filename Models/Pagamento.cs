namespace TopTechApi.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataPagamento { get; set; } = DateTime.Now;
        public string MetodoPagamento { get; set; } = string.Empty;

        public int OrdemServicoId { get; set; }
        public OrdemServico? OrdemServico { get; set; }
    }
}