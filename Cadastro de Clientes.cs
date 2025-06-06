using System;

namespace LojaVirtual
{  
    //cliente da loja virtual
    public class Cliente
    {
        //Cliente unico
        public Guid Id { get; }
        //Nome do cliente
        public string Nome { get; }
        //Email do usuario
        public string Email { get; }
        //CPF usuario
        public string Cpf { get; }
        //Construtor e verificador de Nome, Email e CPF
        public Cliente(string nome, string email, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email é obrigatório.");

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("CPF é obrigatório.");
                
            // Atribui os valores e gera um ID
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}