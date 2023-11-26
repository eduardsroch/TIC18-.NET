using System;

namespace GerenciamentoEstoque
{
    public record Produto(int Codigo, string Nome, int QuantidadeEmEstoque, double PrecoUnitario);
}
