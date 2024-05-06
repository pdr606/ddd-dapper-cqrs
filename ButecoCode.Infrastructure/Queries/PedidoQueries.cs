using ButecoCode.Domain.PedidoContext;
using ButecoCode.Infrastructure.ContextMapping;
using ButecoCode.Infrastructure.Queries.DefaultQuery;

namespace ButecoCode.Infrastructure.Queries
{
    public static class PedidoQueries
    {

        public static Query InserirPedidoItem(PedidoItemEntity pedidoItem)
        {
            var query =
            $@"INSERT INTO {Tables.TablePedidoItem}
            VALUES
            (
                @id,
                @quantidade,
                @datacriacao,
                @bebidaid,
                @pedidoid,
                @preco
            )";

            var parameters = new
            {
                id = pedidoItem.Id,
                quantidade = pedidoItem.Quantidade,
                bebidaid = pedidoItem.BebidaId,
                datacriacao = pedidoItem.DataCriacao,
                pedidoid = pedidoItem.PedidoId,
                preco = pedidoItem.Preco
            };

            return new Query(query, parameters);
        }

        public static Query InserirPedido(PedidoEntity pedido)
        {
            var query =
            $@"INSERT INTO {Tables.TablePedido}
                VALUES (
                @id,
                @valortotal,
                @datacriacao
             )";

            var parameters = new
            {
                id = pedido.Id,
                valortotal = pedido.ValorTotal,
                datacriacao = pedido.DataCriacao
            };

            return new Query(query, parameters);
        }

        public static Query BuscarPedidoPorId(Guid id)
        {
            var query = 
                $@"SELECT * FROM
                {Tables.TablePedido}
                WHERE id = @pedidoid";

            var parameters = new
            {
                pedidoid = id
            };

            return new Query(query, parameters);
        }

        public static Query BuscarPedidoItemPorIdPedido(Guid id)
        {
            var query =
                $@"SELECT * FROM
                {Tables.TablePedidoItem}
                WHERE pedidodid = @pedidoid";

            var parameters = new
            {
                pedidoid = id
            };

            return new Query(query, parameters);
        }
    }
}
