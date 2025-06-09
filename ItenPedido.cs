using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual
{
    // Classe que representa um produto dentro de um pedido, com a quantidade comprada
    public class ItensPedido
    {
        public Produto Produto { get; }     // Produto comprado
        public int Quantidade { get; }      // Quantidade do produto no pedido

        // Construtor: cria um item de pedido com validação
        public ItensPedido(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            Produto = produto;
            Quantidade = quantidade;
        }

        // Valor total sem desconto (preço unitário * quantidade)
        public decimal ValorBruto => Produto.Preco * Quantidade;

        // Desconto de 15% aplicado se a quantidade for 5 ou mais
        public decimal Desconto => Quantidade >= 5 ? Produto.Preco * 0.15m * Quantidade : 0;

        // Valor final com desconto já aplicado
        public decimal ValorComDesconto => ValorBruto - Desconto;

        // Agrupa produtos iguais em uma lista de ItensPedido com suas quantidades
        public static List<ItensPedido> Agrupar(List<Produto> produtos)
        {
            return produtos
                .GroupBy(p => p.Id) //Agrupa produtos do msm ID ou iguais
                .Select(g => new ItensPedido(g.First(), g.Count()))
                .ToList();
        }
    }
}