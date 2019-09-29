using System;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using DesafioSelecao.TesteDeUnidade.Builders;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio.Criterios
{
    public class CriterioDePretendenteComIdadeIgualOuMaiorA45AnosTeste
    {
        private readonly CriterioDePretendenteComIdadeIgualOuMaiorA45Anos _criterioDePretendetenComIdadeMaiorIgualA45Anos;
        private readonly Pessoa _pessoaDois;

        public CriterioDePretendenteComIdadeIgualOuMaiorA45AnosTeste()
        {
            _criterioDePretendetenComIdadeMaiorIgualA45Anos = new CriterioDePretendenteComIdadeIgualOuMaiorA45Anos();
            _pessoaDois = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Tipo, TipoDePessoa.Conjuge).Build();
        }

        [Theory]
        [InlineData(1974, 09, 02)]
        [InlineData(1973, 09, 02)]
        [InlineData(1950, 09, 02)]
        public void Deve_pontuar_familia_quando_criterio_for_atendido(
            int anoDeNascimento, int mesDeNascimento, int diaDeNascimento)
        {
            const int pontuacaoEsperada = 3;
            var dataDeNascimentoDe45Anos = new DateTime(anoDeNascimento, mesDeNascimento, diaDeNascimento);
            var pessoaUm = PessoaBuilder.UmaPessoa().ComDataDeNascimento(dataDeNascimentoDe45Anos).Build();
            var pessoas = new[] { pessoaUm, _pessoaDois };
            var familia = FluentBuilder<Familia>.New().WithCollection(f => f.Pessoas, pessoas).Build();

            var pontuacaoObtida = _criterioDePretendetenComIdadeMaiorIgualA45Anos.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }

        [Theory]
        [InlineData(1975, 09, 02)]
        [InlineData(1996, 09, 02)]
        [InlineData(1980, 09, 02)]
        public void Nao_deve_pontuar_familia_quando_criterio_nao_for_atendido(int anoDeNascimento,
            int mesDeNascimento, int diaDeNascimento)
        {
            const int pontuacaoEsperada = 0;
            var dataDeNascimentoDe45Anos = new DateTime(anoDeNascimento, mesDeNascimento, diaDeNascimento);
            var pessoaUm = FluentBuilder<Pessoa>.New()
                .With(pessoa => pessoa.Tipo, TipoDePessoa.Pretendete)
                .With(pessoa => pessoa.DataDeNascimento, dataDeNascimentoDe45Anos)
                .Build();
            var pessoas = new[] { pessoaUm, _pessoaDois };
            var familia = FluentBuilder<Familia>.New().WithCollection(f => f.Pessoas, pessoas).Build();

            var pontuacaoObtida = _criterioDePretendetenComIdadeMaiorIgualA45Anos.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }
    }
}