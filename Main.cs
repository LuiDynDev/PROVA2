using System;
using System.Collections.Generic;

namespace LojaVirtual
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar cliente
            var cliente = new Cliente("João Silva", "joao@email.com", "123.456.789-00");

            // Criar produtos
            var smartphone = new Produto("Smartphone", 2000m, "Eletronicos");
            var livro = new Produto("Livro C#", 150m, "Livros");

            // Criar pedido
            var pedido = new Pedido(cliente);

            // Adicionar 5 smartphones para desconto por quantidade
            for (int i = 0; i < 5; i++)
                pedido.AdicionarProduto(smartphone);

            // Adicionar 1 livro
            pedido.AdicionarProduto(livro);

            // Definir as estratégias de desconto
            var descontos = new List<IDesconto>
            {
                new DescontoPorCategoria(),
                new DescontoPorQuantidade()
            };

            // Criar a calculadora de desconto
            var calculadora = new CalculadoraDeDesconto(descontos);

            decimal descontoTotal = 0;
            var produtosCalculados = new HashSet<Guid>();

            // Calcular o desconto para cada produto único no pedido
            foreach (var produto in pedido.Produtos)
            {
                if (!produtosCalculados.Contains(produto.Id))
                {
                    int quantidade = pedido.Produtos.FindAll(p => p.Id == produto.Id).Count;
                    descontoTotal += calculadora.CalcularDescontoTotal(produto, quantidade);
                    produtosCalculados.Add(produto.Id);
                }
            }

            // Mostrar resultados no console
            Console.WriteLine($"Cliente: {cliente.Nome}");
            Console.WriteLine($"Total sem desconto: R$ {pedido.ValorTotal:F2}");
            Console.WriteLine($"Desconto total: R$ {descontoTotal:F2}");
            Console.WriteLine($"Total com desconto: R$ {pedido.ValorTotal - descontoTotal:F2}");
        }
    }
}