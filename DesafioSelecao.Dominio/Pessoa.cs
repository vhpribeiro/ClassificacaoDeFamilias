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
        public int Idade { get; }

        public Pessoa(Guid id, string nome, TipoDePessoa tipoDePessoa, DateTime dataDeNascimento)
        {
            Id = id;
            Nome = nome;
            Tipo = tipoDePessoa;
            DataDeNascimento = dataDeNascimento;
            Idade = CalcularIdade(DataDeNascimento, DateTime.Now);
        }

        public void Adicionar(Renda renda)
        {
            Renda = renda;
        }

        private static int CalcularIdade(DateTime dataDeNascimento, DateTime dataDeHoje)
        {
            return (dataDeHoje.Year - dataDeNascimento.Year - 1) +
                   (((dataDeHoje.Month > dataDeNascimento.Month) ||
                     ((dataDeHoje.Month == dataDeNascimento.Month) && (dataDeHoje.Day >= dataDeNascimento.Day))) ? 1 : 0);
        }
    }
}