using System;
using System.Collections.Generic;

namespace LojaVirtual
{
    // Interface para desconto
    public interface IDesconto
    {
        decimal CalcularDesconto(Produto produto, int quantidade);
    }

    // Desconto de 10% para produtos da categoria "Eletronicos"
    public class DescontoPorCategoria : IDesconto
    {
        public decimal CalcularDesconto(Produto produto, int quantidade)
        {
            if (produto.Categoria.ToLower() == "eletronicos")
                return produto.Preco * 0.10m;
            return 0;
        }
    }

    // Desconto de 15% se comprar 5 ou mais unidades
    public class DescontoPorQuantidade : IDesconto
    {
        public decimal CalcularDesconto(Produto produto, int quantidade)
        {
            if (quantidade >= 5)
                return produto.Preco * 0.15m;
            return 0;
        }
    }

    // Calculadora que soma os descontos das estratégias usadas
    public class CalculadoraDeDesconto
    {
        private List<IDesconto> estrategias;

        public CalculadoraDeDesconto(List<IDesconto> estrategias)
        {
            this.estrategias = estrategias;
        }

        public decimal CalcularDescontoTotal(Produto produto, int quantidade)
        {
            decimal descontoTotal = 0;

            foreach (var estrategia in estrategias)
                descontoTotal += estrategia.CalcularDesconto(produto, quantidade);

            return descontoTotal;
        }
    }
}