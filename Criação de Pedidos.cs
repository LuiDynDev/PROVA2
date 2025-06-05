using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual
{
    public class Pedido
    {
        public Guid Id { get; }
        public Cliente Cliente { get; }
        public List<Produto> Produtos { get; }
        public DateTime DataPedido { get; }

        public Pedido(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");

            Id = Guid.NewGuid();
            Cliente = cliente;
            Produtos = new List<Produto>();
            DataPedido = DateTime.Now;
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            Produtos.Add(produto);
        }

        public decimal ValorTotal
        {
            get
            {
                return Produtos.Sum(p => p.Preco);
            }
        }
    }
}