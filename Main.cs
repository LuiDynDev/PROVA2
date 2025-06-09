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

            // Agrupa os produtos do pedido em itens com quantidade
            var itens = ItensPedido.Agrupar(pedido.Produtos);

            // Variáveis para somar os totais
            decimal totalSemDesconto = 0;
            decimal totalDesconto = 0;

            // Título do relatório
            Console.WriteLine("\n--- Detalhes do Pedido ---\n");

            // Percorre cada item do pedido (produto + quantidade)
            foreach (var item in itens)
            {
                // Exibe nome e quantidade do produto
                Console.WriteLine($"{item.Produto.Nome} (x{item.Quantidade})");

                // Exibe o preço de cada unidade
                Console.WriteLine($"Preço unitário: R$ {item.Produto.Preco:F2}");

                // Exibe o total sem desconto (preço * quantidade)
                Console.WriteLine($"Subtotal: R$ {item.ValorBruto:F2}");

                // Exibe o valor do desconto aplicado, se houver
                Console.WriteLine($"Desconto: R$ {item.Desconto:F2}");

                // Exibe o valor final com desconto aplicado
                Console.WriteLine($"Total com desconto: R$ {item.ValorComDesconto:F2}");

                // Espaço entre os itens
                Console.WriteLine();

                // Soma os valores ao total
                totalSemDesconto += item.ValorBruto;
                totalDesconto += item.Desconto;
            }

            // Calcula o valor final com desconto
            decimal totalFinal = totalSemDesconto - totalDesconto;

            // Exibe o resumo do pedido no final
            Console.WriteLine("--- Resumo ---");
            Console.WriteLine($"Total sem desconto: R$ {totalSemDesconto:F2}");
            Console.WriteLine($"Desconto total:     R$ {totalDesconto:F2}");
            Console.WriteLine($"Total com desconto: R$ {totalFinal:F2}");

            // Mostrar resultados no console
            Console.WriteLine($"Cliente: {cliente.Nome}");
            Console.WriteLine($"Total sem desconto: R$ {pedido.ValorTotal:F2}");
            Console.WriteLine($"Desconto total: R$ {descontoTotal:F2}");
            Console.WriteLine($"Total com desconto: R$ {pedido.ValorTotal - descontoTotal:F2}");
        }
    }
}