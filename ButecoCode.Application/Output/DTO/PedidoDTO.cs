namespace ButecoCode.Domain.PedidoContext.DTOs
{
    public record PedidoDTO
    {
        public Guid Id { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
