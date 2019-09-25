using System;

namespace DesafioSelecao.Dominio
{
    public class Pessoa
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public TipoDePessoa Tipo { get; protected set; }
        public DateTime DataDeNascimento { get; protected set; }
        public Renda Renda { get; protected set; }

        public Pessoa(Guid id, string nome, TipoDePessoa tipoDePessoa, DateTime dataDeNascimento, Renda renda)
        {
            Id = id;
            Nome = nome;
            Tipo = tipoDePessoa;
            DataDeNascimento = dataDeNascimento;
            Renda = renda;
        }
    }
}