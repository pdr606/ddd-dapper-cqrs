using Npgsql;
using System.Data;

namespace ButecoCode.Infrastructure.Factory
{
    public static class SqlFactory
    {
        public static IDbConnection PostgresConnection()
        {
            return new NpgsqlConnection("Server=localhost;Database=bar;User Id=postgres;Password=123456;Include Error Detail=true");
        }
    }
}
