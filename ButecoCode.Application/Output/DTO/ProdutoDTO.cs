using System.Text.Json.Serialization;

namespace ButecoCode.Application.Output.DTO
{
    public record ProdutoDTO
    {
        public ProdutoDTO(Guid id, string nome, decimal preco, short? quantidade)
        {
            Id = id;
            Nome = nome;
            Preco = preco.ToString("N2");
            Quantidade = quantidade;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set;}

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public short? Quantidade { get; set; } = null;
    }
}
