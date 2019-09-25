using System;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.Aplicacao.Dtos
{
    public class PessoaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoDePessoa Tipo { get; protected set; }
        public DateTime DataDeNascimento { get; protected set; }
    }
}