using System;

namespace LojaVirtual
{
    public class Produto
    {
        //ID do produto
        public Guid Id { get; }
        //Nome do produto
        public string Nome { get; }
        //Valor do produto
        public decimal Preco { get; }
        //Categoria do produto
        public string Categoria { get; }
        //Construtor da classe e validação Nome, Preço e Categoria do produto
        public Produto(string nome, decimal preco, string categoria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto é obrigatório.");

            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("Categoria é obrigatória.");
            // Adiciona valores e gera um ID único 
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
        }
    }
}