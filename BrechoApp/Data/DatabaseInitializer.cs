using Microsoft.Data.Sqlite;

namespace BrechoApp.Data
{
    /// <summary>
    /// Responsável por criar todas as tabelas do banco SQLite.
    /// Este arquivo define o schema oficial do sistema.
    /// Sempre que um novo campo é adicionado em um modelo ou repositório,
    /// ele deve ser incluído aqui.
    /// </summary>
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using var connection = Conexao.GetConnection();
            connection.Open();

            // -----------------------------------------------------------------
            // IMPORTANTE:
            // SQLite NÃO altera tabelas existentes.
            // Se você mudar o schema, precisa APAGAR o arquivo brecho.db
            // para que ele seja recriado com a estrutura nova.
            // -----------------------------------------------------------------

            string sql = @"

                ---------------------------------------------------------
                -- TABELA: PARCEIROS DE NEGÓCIO (PN)
                -- CpfCnpj aceita CPF ou CNPJ (até 18 caracteres formatado)
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS ParceirosNegocio (
                    CodigoParceiro TEXT PRIMARY KEY,
                    Nome TEXT NOT NULL,
                    TipoParceiro TEXT DEFAULT 'Outro',
                    CpfCnpj TEXT NOT NULL,
                    Apelido TEXT NOT NULL,
                    Telefone TEXT NOT NULL,

                    Endereco TEXT,
                    Email TEXT,

                    Banco TEXT,
                    Agencia TEXT,
                    Conta TEXT,
                    Pix TEXT,

                    PercentualComissao REAL,
                    ComissaoDeVendedor REAL DEFAULT NULL,
                    AutorizaDoacao INTEGER,

                    Observacao TEXT,
                    Aniversario TEXT,

                    SaldoCredito REAL,

                    DataCriacao TEXT,
                    UltimaAtualizacao TEXT
                );

                ---------------------------------------------------------
                -- TABELA DE VENDEDORES
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS Vendedores (
                    CodigoVendedor TEXT PRIMARY KEY,
                    Nome TEXT NOT NULL,
                    CPF TEXT,
                    Telefone TEXT,
                    Email TEXT,
                    Endereco TEXT,

                    Banco TEXT,
                    Agencia TEXT,
                    Conta TEXT,

                    ComissaoVendedor REAL DEFAULT 0,
                    Observacao TEXT,

                    Ativo INTEGER DEFAULT 1
                );

                ---------------------------------------------------------
                -- TABELA DE LOTE DE RECEBIMENTO
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS LoteRecebimento (
                    CodigoLoteRecebimento TEXT PRIMARY KEY,
                    CodigoParceiro TEXT NOT NULL,

                    DataCriacao TEXT NOT NULL,
                    DataRecebimento TEXT,
                    DataAprovacao TEXT,

                    StatusLote TEXT NOT NULL,

                    TotalSugerido REAL DEFAULT 0,
                    TotalVenda REAL DEFAULT 0,
                    TotalComissao REAL DEFAULT 0,
                    TotalCreditoParceiro REAL DEFAULT 0,

                    Observacoes TEXT,
                    UltimaAtualizacao TEXT,

                    FOREIGN KEY (CodigoParceiro) REFERENCES ParceirosNegocio (CodigoParceiro)
                );

                ---------------------------------------------------------
                -- TABELA DE ITENS DO LOTE
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS ItemLote (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    CodigoLoteRecebimento TEXT NOT NULL,
                    CodigoParceiro TEXT NOT NULL,

                    NomeDoItem TEXT NOT NULL,
                    MarcaDoItem TEXT NOT NULL,
                    CategoriaDoItem TEXT NOT NULL,
                    TamanhoCorDoItem TEXT NOT NULL,

                    ObservacaoDoItem TEXT,

                    PrecoSugeridoDoItem REAL DEFAULT 0,
                    PrecoVendaDoItem REAL NOT NULL,

                    StatusItem TEXT NOT NULL,

                    CodigoProdutoGerado TEXT,

                    DataCriacao TEXT NOT NULL,
                    UltimaAtualizacao TEXT NOT NULL,

                    FOREIGN KEY (CodigoLoteRecebimento) REFERENCES LoteRecebimento (CodigoLoteRecebimento),
                    FOREIGN KEY (CodigoParceiro) REFERENCES ParceirosNegocio (CodigoParceiro)
                );

                ---------------------------------------------------------
                -- TABELA DE CLIENTES
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS Clientes (
                    CodigoCliente TEXT PRIMARY KEY,
                    Nome TEXT NOT NULL,
                    CPF TEXT,
                    Telefone TEXT,
                    Endereco TEXT,
                    Email TEXT,
                    Observacao TEXT,
                    Aniversario TEXT,
                    SaldoCredito REAL DEFAULT 0
                );

                ---------------------------------------------------------
                -- TABELA DE PRODUTOS
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS Produtos (
                    CodigoProduto TEXT PRIMARY KEY,
                    CodigoLoteRecebimento TEXT NOT NULL,

                    NomeDoItem TEXT NOT NULL,
                    MarcaDoItem TEXT NOT NULL,
                    ObservacaoDoItem TEXT,
                    CategoriaDoItem TEXT NOT NULL,
                    TamanhoCorDoItem TEXT NOT NULL,

                    PrecoVendaDoItem REAL NOT NULL,
                    StatusDoProduto TEXT NOT NULL,

                    CodigoParceiro TEXT NOT NULL,

                    DataCriacao TEXT NOT NULL,
                    UltimaAtualizacao TEXT NOT NULL,

                    FOREIGN KEY (CodigoParceiro) REFERENCES ParceirosNegocio (CodigoParceiro),
                    FOREIGN KEY (CodigoLoteRecebimento) REFERENCES LoteRecebimento (CodigoLoteRecebimento)
                );

                ---------------------------------------------------------
                -- TABELA DE CRÉDITOS DO PARCEIRO
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS CreditoParceiro (
                    CodigoCredito TEXT PRIMARY KEY,
                    CodigoParceiro TEXT NOT NULL,
                    ValorCredito REAL NOT NULL,
                    DataCredito TEXT NOT NULL,
                    OrigemCredito TEXT,

                    FOREIGN KEY (CodigoParceiro) REFERENCES ParceirosNegocio (CodigoParceiro)
                );

                ---------------------------------------------------------
                -- TABELA DE LOTE DE DEVOLUÇÃO
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS LoteDevolucao (
                    CodigoLoteDevolucao TEXT PRIMARY KEY,
                    CodigoParceiro TEXT NOT NULL,
                    DataDevolucao TEXT,
                    StatusDevolucao TEXT,

                    FOREIGN KEY (CodigoParceiro) REFERENCES ParceirosNegocio (CodigoParceiro)
                );

                ---------------------------------------------------------
                -- TABELA DE PRODUTOS DEVOLVIDOS
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS ProdutosDevolucao (
                    CodigoProdutoDevolucao TEXT PRIMARY KEY,
                    CodigoLoteDevolucao TEXT NOT NULL,
                    CodigoProduto TEXT NOT NULL,
                    MotivoDevolucao TEXT,
                    DataDevolucao TEXT,

                    FOREIGN KEY (CodigoLoteDevolucao) REFERENCES LoteDevolucao (CodigoLoteDevolucao),
                    FOREIGN KEY (CodigoProduto) REFERENCES Produtos (CodigoProduto)
                );

                ---------------------------------------------------------
                -- TABELA DE VENDAS
                -- Sistema completo de vendas com suporte a múltiplos itens
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS Vendas (
                    IdVenda INTEGER PRIMARY KEY AUTOINCREMENT,
                    CodigoVenda TEXT NOT NULL UNIQUE,
                    IdVendedor TEXT NOT NULL,
                    IdCliente TEXT NOT NULL,
                    DataVenda TEXT NOT NULL,
                    ValorTotalOriginal REAL NOT NULL,
                    DescontoPercentual REAL DEFAULT 0,
                    DescontoValor REAL DEFAULT 0,
                    Campanha TEXT,
                    DescontoCampanhaPercentual REAL DEFAULT 0,
                    DescontoCampanha REAL DEFAULT 0,
                    ValorTotalFinal REAL NOT NULL,
                    FormaPagamento TEXT NOT NULL,
                    Observacoes TEXT,
                    DataCriacao TEXT NOT NULL,
                    
                    FOREIGN KEY (IdVendedor) REFERENCES ParceirosNegocio (CodigoParceiro),
                    FOREIGN KEY (IdCliente) REFERENCES ParceirosNegocio (CodigoParceiro)
                );

                ---------------------------------------------------------
                -- TABELA DE ITENS DAS VENDAS
                -- Armazena cada produto vendido em uma venda
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS VendasItens (
                    IdVendaItem INTEGER PRIMARY KEY AUTOINCREMENT,
                    IdVenda INTEGER NOT NULL,
                    IdProduto TEXT NOT NULL,
                    IdFornecedor TEXT NOT NULL,
                    PrecoOriginal REAL NOT NULL,
                    PrecoFinalNegociado REAL NOT NULL,
                    
                    FOREIGN KEY (IdVenda) REFERENCES Vendas (IdVenda),
                    FOREIGN KEY (IdProduto) REFERENCES Produtos (CodigoProduto),
                    FOREIGN KEY (IdFornecedor) REFERENCES ParceirosNegocio (CodigoParceiro)
                );

                ---------------------------------------------------------
                -- TABELA DE CATEGORIAS DE PRODUTOS
                ---------------------------------------------------------
                CREATE TABLE IF NOT EXISTS Categorias (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NomeCategoria TEXT NOT NULL UNIQUE,
                    DataCriacao TEXT NOT NULL
                );
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.ExecuteNonQuery();

            // Run migrations for existing databases
            RunMigrations(connection);
        }

        /// <summary>
        /// Executa migrações para adicionar novas colunas em bancos de dados existentes.
        /// </summary>
        private static void RunMigrations(SqliteConnection connection)
        {
            // Migration: Add DescontoCampanhaPercentual column to Vendas table if it doesn't exist
            try
            {
                string checkColumnSql = "SELECT COUNT(*) FROM pragma_table_info('Vendas') WHERE name='DescontoCampanhaPercentual'";
                using var checkCmd = new SqliteCommand(checkColumnSql, connection);
                var columnExists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;

                if (!columnExists)
                {
                    string addColumnSql = "ALTER TABLE Vendas ADD COLUMN DescontoCampanhaPercentual REAL DEFAULT 0";
                    using var alterCmd = new SqliteCommand(addColumnSql, connection);
                    alterCmd.ExecuteNonQuery();
                }
            }
            catch (SqliteException ex)
            {
                // Log the error but don't fail initialization
                // The column might already exist or the table might not exist yet
                System.Diagnostics.Debug.WriteLine($"Migration warning: {ex.Message}");
            }
        }
    }
}
