using System;

namespace LojaVirtual
{
    public class Cliente
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string Cpf { get; }

        public Cliente(string nome, string email, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email é obrigatório.");

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("CPF é obrigatório.");

            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}