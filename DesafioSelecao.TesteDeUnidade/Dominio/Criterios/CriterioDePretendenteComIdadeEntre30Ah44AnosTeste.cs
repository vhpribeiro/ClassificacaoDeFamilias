using System;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using DesafioSelecao.TesteDeUnidade.Builders;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio.Criterios
{
    public class CriterioDePretendenteComIdadeEntre30Ah44AnosTeste
    {
        private readonly CriterioDePretendenteComIdadeEntre30Ah44Anos _criterio;

        public CriterioDePretendenteComIdadeEntre30Ah44AnosTeste()
        {
            _criterio = new CriterioDePretendenteComIdadeEntre30Ah44Anos();

        }

        [Theory]
        [InlineData(1989, 09, 02)]
        [InlineData(1975, 09, 02)]
        [InlineData(1980, 09, 02)]
        public void Deve_pontuar_familia_quando_criterio_for_atendido(int anoDeNascimento, int mesDeNascimento, int diaDeNascimento)
        {
            const int pontuacaoEsperada = 2;
            var dataDeNascimento = new DateTime(anoDeNascimento, mesDeNascimento,  diaDeNascimento);
            var pretendente = PessoaBuilder.UmaPessoa().ComTipo(TipoDePessoa.Pretendete)
                .ComDataDeNascimento(dataDeNascimento).Build();
            var pessoas = new[] {pretendente};
            var familia = FluentBuilder<Familia>.New().WithCollection(f => f.Pessoas, pessoas).Build();

            var pontuacaoObtida = _criterio.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }

        [Theory]
        [InlineData(1990, 09, 02)]
        [InlineData(1974, 09, 02)]
        [InlineData(1960, 09, 02)]
        [InlineData(2000, 09, 02)]
        public void Nao_deve_pontuar_familia_quando_criterio_nao_for_atendido(int anoDeNascimento, 
            int mesDeNascimento, int diaDeNascimento)
        {
            const int pontuacaoEsperada = 0;
            var dataDeNascimento = new DateTime(anoDeNascimento, mesDeNascimento, diaDeNascimento);
            var pretendente = PessoaBuilder.UmaPessoa().ComTipo(TipoDePessoa.Pretendete)
                .ComDataDeNascimento(dataDeNascimento).Build();
            var pessoas = new[] { pretendente };
            var familia = FluentBuilder<Familia>.New().WithCollection(f => f.Pessoas, pessoas).Build();

            var pontuacaoObtida = _criterio.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }
    }
}