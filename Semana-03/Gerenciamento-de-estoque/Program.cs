using System;

namespace GerenciamentoEstoque
{
    class Program
    {
        static Estoque estoque = new Estoque();

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Cadastro de Produtos");
                Console.WriteLine("2. Consulta de Produtos");
                Console.WriteLine("3. Atualização de Estoque");
                Console.WriteLine("4. Relatórios");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastroDeProdutos();
                        break;
                    case "2":
                        ConsultaDeProdutos();
                        break;
                    case "3":
                        AtualizacaoDeEstoque();
                        break;
                    case "4":
                        MenuRelatorios();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void CadastroDeProdutos()
        {
            try
            {
                Console.WriteLine(" === Cadastro de Produtos === ");
                Console.Write("Código: ");
                int codigo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Quantidade em Estoque: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Preço Unitário: ");
                double preco = Convert.ToDouble(Console.ReadLine());

                Produto produto = new Produto(codigo, nome, quantidade, preco);
                estoque.AdicionarProduto(produto);
                Console.WriteLine("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar produto: {ex.Message}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void ConsultaDeProdutos()
        {
            try
            {
                Console.WriteLine("=== Consulta de Produtos ===");
                Console.Write("Buscar produto por código: ");
                int codigoConsulta = Convert.ToInt32(Console.ReadLine());

                var produtoEncontrado = estoque.BuscarProdutoPorCodigo(codigoConsulta);
                Console.WriteLine($"Produto encontrado: {produtoEncontrado.Nome}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar produto: {ex.Message}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void AtualizacaoDeEstoque()
        {
            try
            {
                Console.WriteLine("=== Atualização de Estoque ===");
                Console.Write("Código do produto: ");
                int codigoAtualizacao = Convert.ToInt32(Console.ReadLine());
                Console.Write("Quantidade a adicionar: ");
                int quantidadeAtualizacao = Convert.ToInt32(Console.ReadLine());

                estoque.AtualizarEstoque(codigoAtualizacao, quantidadeAtualizacao);
                Console.WriteLine("Estoque atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar estoque: {ex.Message}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void MenuRelatorios()
        {
            try
            {
                Console.WriteLine("=== Relatórios ===");
                Console.WriteLine("1. Lista de produtos com quantidade abaixo de um limite");
                Console.WriteLine("2. Lista de produtos com valor entre um mínimo e um máximo");
                Console.WriteLine("3. Informar o valor total do estoque e o valor total de cada produto");
                Console.WriteLine("4. Voltar ao menu principal");
                Console.Write("Escolha uma opção: ");
                string opcaoRelatorio = Console.ReadLine();

                switch (opcaoRelatorio)
                {
                    case "1":
                        Console.Write("Limite de quantidade: ");
                        int limiteQuantidade = Convert.ToInt32(Console.ReadLine());
                        Relatorios.GerarRelatorioProdutosAbaixoLimite(estoque, limiteQuantidade);
                        break;
                    case "2":
                        Console.Write("Valor mínimo: ");
                        double valorMinimo = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Valor máximo: ");
                        double valorMaximo = Convert.ToDouble(Console.ReadLine());
                        Relatorios.GerarRelatorioProdutosEntreValores(estoque, valorMinimo, valorMaximo);
                        break;
                    case "3":
                        Relatorios.GerarRelatorioValorTotalEstoque(estoque);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar relatório: {ex.Message}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
