using System;
using System.Linq;

namespace GerenciamentoEstoque
{
    public class Relatorios
    {
        public static void GerarRelatorioProdutosAbaixoLimite(Estoque estoque, int limite)
        {
            var produtos = estoque.ProdutosAbaixoDoLimite(limite);
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Produto abaixo do limite: {produto.Nome}, Quantidade: {produto.QuantidadeEmEstoque}");
            }
        }

        public static void GerarRelatorioProdutosEntreValores(Estoque estoque, double minimo, double maximo)
        {
            var produtos = estoque.ProdutosEntreValores(minimo, maximo);
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Produto entre valores: {produto.Nome}, Preço: {produto.PrecoUnitario}");
            }
        }

        public static void GerarRelatorioValorTotalEstoque(Estoque estoque)
        {
            var valorTotalEstoque = estoque.ValorTotalEstoque();
            Console.WriteLine($"Valor total do estoque: {valorTotalEstoque}");

            var valorPorProduto = estoque.ValorTotalPorProduto();
            foreach (var kvp in valorPorProduto)
            {
                Console.WriteLine($"Produto: {kvp.Key.Nome}, Valor Total: {kvp.Value}");
            }
        }
    }
}
