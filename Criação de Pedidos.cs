using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual
{
    // Pedido feito por um cliente na loja
    public class Pedido
    {
        // Pedido único
        public Guid Id { get; }

        // Quem fez o pedido
        public Cliente Cliente { get; }

        // Itens incluídos no pedido (produto + quantidade)
        public List<ItemPedido> Itens { get; }

        // Data e hora do pedido
        public DateTime DataPedido { get; }

        public Pedido(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");

            Id = Guid.NewGuid();
            Cliente = cliente;
            Itens = new List<ItemPedido>();
            DataPedido = DateTime.Now;
        }

        // Adiciona produto ao pedido com controle de quantidade
        public void AdicionarProduto(Produto produto, int quantidade = 1)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            var itemExistente = Itens.FirstOrDefault(i => i.Produto.Id == produto.Id);

            if (itemExistente != null)
            {
                itemExistente.AdicionarQuantidade(quantidade);
            }
            else
            {
                Itens.Add(new ItemPedido(produto, quantidade));
            }
        }

        // Calcula o preço total dos produtos do pedido (sem frete)
        public decimal ValorTotal
        {
            get
            {
                return Itens.Sum(i => i.ValorBruto);
            }
        }
    }
}