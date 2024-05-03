using ButecoCode.Domain.Common.Assertions;
using ButecoCode.Domain.Common.Entity;

namespace ButecoCode.Domain.Bebida
{
    public class ProdutoEntity : BaseEntity , IValidation
    {
        protected static decimal MIN_PRECO_PRODUTO = 0;

        private ProdutoEntity(string nome, decimal preco)
        {
            Nome = nome.ToUpper();
            Preco = preco;
            Valildar();
        }

        protected ProdutoEntity() { }

        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        public static ProdutoEntity CriarProduto(string nome, decimal preco)
        {
            return new ProdutoEntity(nome, preco);
        }

        public void Valildar()
        {
            Validations.ValidarSeMenorQue(Preco, MIN_PRECO_PRODUTO, $"O campo Preço não pode ser menor ou igual a {MIN_PRECO_PRODUTO}.");
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Preco}";
        }
    }
}
