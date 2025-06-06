using System;
using System.Collections.Generic;

namespace LojaVirtual
{
    public class RelatorioDePedidos
    {
        private List<Pedido> pedidos = new List<Pedido>();

        public void AdicionarPedido(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));

            pedidos.Add(pedido);
        }

        public void Exibir()
        {
            Console.WriteLine("===== Relatório de Pedidos =====");

            if (pedidos.Count == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado.");
                return;
            }

            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido: {pedido.Id}");
                Console.WriteLine($"Cliente: {pedido.Cliente.Nome}");
                Console.WriteLine($"Data: {pedido.DataPedido}");
                Console.WriteLine("Produtos:");

                foreach (var produto in pedido.Produtos)
                {
                    Console.WriteLine($" - {produto.Nome} | Categoria: {produto.Categoria} | Preço: R$ {produto.Preco:F2}");
                }

                Console.WriteLine($"Valor Total: R$ {pedido.ValorTotal:F2}");
                Console.WriteLine("-------------------------------");
            }
        }
    }
}