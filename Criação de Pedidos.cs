using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual
{
    //edido feito por um cliente na loja
    public class Pedido
    {
        //Pedido Unico
        public Guid Id { get; }
        //Quem fez o pedido
        public Cliente Cliente { get; }
        //Produtos inluidos no pedido
        public List<Produto> Produtos { get; }
        //Data e hora do pedido
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
            //Adiciona produto ao pedido
        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            Produtos.Add(produto);
        }
            //calcula o preço dos produtos do pedido, sem o frete
        public decimal ValorTotal
        {
            get
            {
                return Produtos.Sum(p => p.Preco);
            }
        }
    }
}