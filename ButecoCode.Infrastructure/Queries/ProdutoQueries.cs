﻿using ButecoCode.Domain.Bebida;
using ButecoCode.Infrastructure.ContextMapping;
using ButecoCode.Infrastructure.Queries.DefaultQuery;

namespace ButecoCode.Infrastructure.Queries
{
    public static class ProdutoQueries
    {
        public static Query InserirProduto(ProdutoEntity entity)
        {

            var query = 
            $@"INSERT INTO {Tables.TabelaProduto}
            VALUES
            (
                @id,
                @nome,
                @preco,
                @datacriacao
            )";

            var parameters = new
            {
                id = entity.Id,
                nome = entity.Nome,
                preco = entity.Preco,
                datacriacao = entity.DataCriacao
            };

            return new Query(query, parameters);
        }

        public static Query BuscarTodosProdutos()
        {
            var query =
            $@"SELECT
            id,
            nome,
            preco
            FROM {Tables.TabelaProduto};";

            return new Query(query);
        }
    }
}
