using ButecoCode.Application.Output.DTO;
using ButecoCode.Domain.Bebida;

namespace ButecoCode.Application.Output.Mapper

{
    public static partial class EntityMapper
    {
        public static ProdutoDTO ToDTO(ProdutoEntity entity)
        {
            return new ProdutoDTO(entity.Id,
                                  entity.Nome,
                                  entity.Preco.ToString("N2").Replace('.', ','));
        }
    }
}
