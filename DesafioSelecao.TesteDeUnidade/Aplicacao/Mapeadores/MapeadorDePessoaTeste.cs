using System;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Aplicacao.Mapeadores;
using DesafioSelecao.Dominio;
using ExpectedObjects;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Aplicacao.Mapeadores
{
    public class MapeadorDePessoaTeste
    {
        [Fact]
        public void Deve_mapear_uma_pessoa()
        {
            var id = Guid.NewGuid();
            DateTime dataDeNascimento = new DateTime(2019,06,17);
            const string nome = "Vitor";
            const TipoDePessoa tipo = TipoDePessoa.Pretendete;
            var pessoaDto = new PessoaDto
            {
                Id = id,
                DataDeNascimento = dataDeNascimento,
                Nome = nome,
                Tipo = tipo
            };
            var pessoaEsperada = new
            {
                Id = id,
                DataDeNascimento = dataDeNascimento,
                Nome = nome,
                Tipo = tipo
            };

            var pessoaObtida = MapeadorDePessoa.Mapear(pessoaDto);

            pessoaEsperada.ToExpectedObject().ShouldMatch(pessoaObtida);
        }
    }
}