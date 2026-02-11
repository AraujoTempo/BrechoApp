using System.IO;

namespace BrechoApp.Data
{
    public static class DatabaseConfig
    {
        static DatabaseConfig()
        {
            // Garante que a pasta Data existe
            string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);

            // Monta o caminho ABSOLUTO do banco
            ConnectionString = $"Data Source={Path.Combine(dataFolder, "brecho.db")}";
        }

        // Caminho final do banco (agora correto)
        public static string ConnectionString { get; private set; }
    }
}

