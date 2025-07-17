using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos
{
    internal class RelatorioMsg
    {
        private readonly string connectionString=ConnectionManager.GetConnectionString("Admin");

        public RelatorioMsg(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Quantidade de Produtos em estoque (com estoque > 0)
        public async Task<int> GetQuantidadeProdutosEmEstoqueAsync()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Produtos 
                WHERE Ativo = 1 AND QuantidadeAtual > 0";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // Quantidade de Fornecedores ativos
        public async Task<int> GetQuantidadeFornecedoresAsync()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Fornecedores 
                WHERE Ativo = 1";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // Quantidade de Clientes Ativos
        public async Task<int> GetQuantidadeClientesAtivosAsync()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Clientes 
                WHERE Ativo = 1";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // Total de vendas Hoje (assumindo que orçamentos aprovados representam vendas)
        public async Task<decimal> GetTotalVendasHojeAsync()
        {
            string query = @"
                SELECT ISNULL(SUM(io.Quantidade * io.PrecoUnitario * (1 - io.Desconto/100)), 0)
                FROM Orcamentos o
                INNER JOIN ItensOrcamento io ON o.ID = io.OrcamentoID
                WHERE o.Status = 'Aprovado' 
                AND CAST(o.DataCadastro AS DATE) = CAST(GETDATE() AS DATE)
                AND o.Ativo = 1 
                AND io.Ativo = 1";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    var result = await command.ExecuteScalarAsync();
                    return result != DBNull.Value ? (decimal)result : 0;
                }
            }
        }

        // Valor Total em Estoque
        public async Task<decimal> GetValorTotalEmEstoqueAsync()
        {
            string query = @"
                SELECT ISNULL(SUM(QuantidadeAtual * PrecoCusto), 0)
                FROM Produtos 
                WHERE Ativo = 1 AND QuantidadeAtual > 0";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    var result = await command.ExecuteScalarAsync();
                    return result != DBNull.Value ? (decimal)result : 0;
                }
            }
        }

        // Orçamentos em Espera (assumindo status diferente de Aprovado/Rejeitado)
        public async Task<int> GetOrcamentosEmEsperaAsync()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Orcamentos 
                WHERE Status NOT IN ('Aprovado', 'Rejeitado', 'Cancelado')
                AND Ativo = 1";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // Orçamentos Aprovados
        public async Task<int> GetOrcamentosAprovadosAsync()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Orcamentos 
                WHERE Status = 'Aprovado' AND Ativo = 1";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // Orçamentos Não-Aprovados (Rejeitados)
        public async Task<int> GetOrcamentosNaoAprovadosAsync()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Orcamentos 
                WHERE Status = 'Rejeitado' AND Ativo = 1";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // Quantidade de Itens Vencendo esta Semana
        public async Task<int> GetItensVencendoEstaSemanaAsync()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Produtos 
                WHERE Ativo = 1 
                AND DataValidade BETWEEN GETDATE() AND DATEADD(DAY, 7, GETDATE())";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // Quantidade de Itens em Promoção
        public async Task<int> GetItensEmPromocaoAsync()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Produtos 
                WHERE Ativo = 1 
                AND PromocaoAtiva = 1 
                AND InicioPromocao <= GETDATE() 
                AND (FimPromocao IS NULL OR FimPromocao >= GETDATE())";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // Método para obter todas as métricas de uma vez
        public async Task<RelatorioData> GetRelatorioCompletoAsync()
        {
            return new RelatorioData
            {
                QuantidadeProdutosEstoque = await GetQuantidadeProdutosEmEstoqueAsync(),
                QuantidadeFornecedores = await GetQuantidadeFornecedoresAsync(),
                QuantidadeClientesAtivos = await GetQuantidadeClientesAtivosAsync(),
                TotalVendasHoje = await GetTotalVendasHojeAsync(),
                ValorTotalEstoque = await GetValorTotalEmEstoqueAsync(),
                OrcamentosEmEspera = await GetOrcamentosEmEsperaAsync(),
                OrcamentosAprovados = await GetOrcamentosAprovadosAsync(),
                OrcamentosNaoAprovados = await GetOrcamentosNaoAprovadosAsync(),
                ItensVencendoEstaSemana = await GetItensVencendoEstaSemanaAsync(),
                ItensEmPromocao = await GetItensEmPromocaoAsync()
            };
        }
    }

    // Classe auxiliar para retornar todos os dados do relatório
    public class RelatorioData
    {
        public int QuantidadeProdutosEstoque { get; set; }
        public int QuantidadeFornecedores { get; set; }
        public int QuantidadeClientesAtivos { get; set; }
        public decimal TotalVendasHoje { get; set; }
        public decimal ValorTotalEstoque { get; set; }
        public int OrcamentosEmEspera { get; set; }
        public int OrcamentosAprovados { get; set; }
        public int OrcamentosNaoAprovados { get; set; }
        public int ItensVencendoEstaSemana { get; set; }
        public int ItensEmPromocao { get; set; }
    }
}
