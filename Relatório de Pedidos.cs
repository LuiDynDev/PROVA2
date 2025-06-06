using System;
using System.Collections.Generic;

namespace LojaVirtual
{
    //armazenar e exibir um relatório dos pedidos realizados
    public class RelatorioDePedidos
    {
        //Lista que armazena todos os pedidos
        private List<Pedido> pedidos = new List<Pedido>();
        // Adiciona um novo pedido
        public void AdicionarPedido(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));

            pedidos.Add(pedido);
        }
        // Exibe no console um relatório com todos os pedidos
        public void Exibir()
        {
            Console.WriteLine("===== Relatório de Pedidos =====");

            if (pedidos.Count == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado.");
                return;
            }
            //Detalhes do pedido 
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido: {pedido.Id}");
                Console.WriteLine($"Cliente: {pedido.Cliente.Nome}");
                Console.WriteLine($"Data: {pedido.DataPedido}");
                Console.WriteLine("Produtos:");

                // Lista todos os produtos do pedido
                foreach (var produto in pedido.Produtos)
                {
                    Console.WriteLine($" - {produto.Nome} | Categoria: {produto.Categoria} | Preço: R$ {produto.Preco:F2}");
                }

                //Valor do pedido
                Console.WriteLine($"Valor Total: R$ {pedido.ValorTotal:F2}");
                Console.WriteLine("-------------------------------");
            }
        }
    }
}