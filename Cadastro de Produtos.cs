using System;

namespace LojaVirtual
{
    public class Produto
    {
        public Guid Id { get; }
        public string Nome { get; }
        public decimal Preco { get; }
        public string Categoria { get; }

        public Produto(string nome, decimal preco, string categoria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto é obrigatório.");

            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("Categoria é obrigatória.");

            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
        }
    }
}