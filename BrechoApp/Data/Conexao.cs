using Microsoft.Data.Sqlite;

namespace BrechoApp.Data
{
    /// <summary>
    /// Classe responsável por centralizar a criação de conexões com o banco SQLite.
    /// Mantém a string de conexão em um único ponto, facilitando manutenção.
    /// </summary>
    public class Conexao
    {
        // ---------------------------------------------------------------------
        // STRING DE CONEXÃO
        //
        // Aponta para o arquivo físico do banco SQLite.
        // Se você quiser trocar o nome do arquivo ou o caminho (ex: pasta Data),
        // basta alterar aqui.
        // ---------------------------------------------------------------------
        private static readonly string connectionString = DatabaseConfig.ConnectionString;


        // ---------------------------------------------------------------------
        // OBTÉM UMA NOVA CONEXÃO
        //
        // Sempre que um repositório precisar falar com o banco, chama este método.
        // O padrão é:
        //   using var conn = Conexao.GetConnection();
        //   conn.Open();
        //
        // A responsabilidade de abrir/fechar a conexão fica no chamador.
        // ---------------------------------------------------------------------
        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }
    }
}

