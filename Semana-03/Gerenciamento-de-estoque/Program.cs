using System;

namespace GerenciamentoEstoque
{
    class Program
    {
        static void Main(string[] args)
        {
            Estoque estoque = new Estoque();

            try
            {
                // Entrada de produtos
                Console.WriteLine("Adicionar Produto 1:");
                Console.Write("Código: ");
                int codigo1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nome: ");
                string nome1 = Console.ReadLine();
                Console.Write("Quantidade em Estoque: ");
                int quantidade1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Preço Unitário: ");
                double preco1 = Convert.ToDouble(Console.ReadLine());

                Produto produto1 = new Produto(codigo1, nome1, quantidade1, preco1);
                estoque.AdicionarProduto(produto1);

                Console.WriteLine("Adicionar Produto 2:");
                Console.Write("Código: ");
                int codigo2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nome: ");
                string nome2 = Console.ReadLine();
                Console.Write("Quantidade em Estoque: ");
                int quantidade2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Preço Unitário: ");
                double preco2 = Convert.ToDouble(Console.ReadLine());

                Produto produto2 = new Produto(codigo2, nome2, quantidade2, preco2);
                estoque.AdicionarProduto(produto2);

                // Consulta de produto por código
                Console.Write("Buscar produto por código: ");
                int codigoConsulta = Convert.ToInt32(Console.ReadLine());

                var produtoEncontrado = estoque.BuscarProdutoPorCodigo(codigoConsulta);
                Console.WriteLine($"Produto encontrado: {produtoEncontrado.Nome}");

                // Atualização de estoque
                Console.Write("Atualizar quantidade de um produto (Código): ");
                int codigoAtualizacao = Convert.ToInt32(Console.ReadLine());
                Console.Write("Quantidade a adicionar (positivo) ou remover (negativo): ");
                int quantidadeAtualizacao = Convert.ToInt32(Console.ReadLine());

                estoque.AtualizarEstoque(codigoAtualizacao, quantidadeAtualizacao);

                // Gerar relatórios
                Console.WriteLine("Produtos abaixo de um limite de quantidade:");
                Relatorios.GerarRelatorioProdutosAbaixoLimite(estoque, 15);

                Console.WriteLine("Produtos com valor entre mínino e máximo:");
                Relatorios.GerarRelatorioProdutosEntreValores(estoque, 5.0, 10.0);

                Console.WriteLine("Relatório de valor total do estoque e valor total por produto:");
                Relatorios.GerarRelatorioValorTotalEstoque(estoque);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
