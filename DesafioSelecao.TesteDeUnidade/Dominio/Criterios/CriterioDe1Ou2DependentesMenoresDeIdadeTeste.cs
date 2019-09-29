using System;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using DesafioSelecao.TesteDeUnidade.Builders;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio.Criterios
{
    public class CriterioDe1Ou2DependentesMenoresDeIdadeTeste
    {
        private readonly CriterioDe1Ou2DependentesMenoresDeIdade _criterio;

        public CriterioDe1Ou2DependentesMenoresDeIdadeTeste()
        {
            _criterio = new CriterioDe1Ou2DependentesMenoresDeIdade();
        }

        [Fact]
        public void Deve_pontuar_familia_quando_tiver_um_filho_menor_de_idade()
        {
            const int pontuacaoEsperada = 2;
            var dependenteMenorDeIdadeUm = PessoaBuilder.UmaPessoa()
                .ComTipo(TipoDePessoa.Dependente)
                .ComDataDeNascimento(new DateTime(2006, 12, 1))
                .Build();
            var pretendente = PessoaBuilder.UmaPessoa().ComTipo(TipoDePessoa.Pretendete).Build();
            var pessoas = new[]
                {dependenteMenorDeIdadeUm, pretendente};
            var familia = FluentBuilder<Familia>.New()
                .WithCollection(f => f.Pessoas, pessoas)
                .Build();

            var pontuacaoObtida = _criterio.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }

        [Fact]
        public void Deve_pontuar_familia_quando_tiver_dois_filhos_menores_de_idade()
        {
            const int pontuacaoEsperada = 2;
            var dependenteMenorDeIdadeUm = PessoaBuilder.UmaPessoa()
                .ComTipo(TipoDePessoa.Dependente)
                .ComDataDeNascimento(new DateTime(2006, 12, 1))
                .Build();
            var dependenteMenorDeIdadeDois = PessoaBuilder.UmaPessoa()
                .ComTipo(TipoDePessoa.Dependente)
                .ComDataDeNascimento(new DateTime(2005, 12, 1))
                .Build();
            var pretendente = PessoaBuilder.UmaPessoa().ComTipo(TipoDePessoa.Pretendete).Build();
            var pessoas = new[]
                {dependenteMenorDeIdadeUm, dependenteMenorDeIdadeDois, pretendente};
            var familia = FluentBuilder<Familia>.New()
                .WithCollection(f => f.Pessoas, pessoas)
                .Build();

            var pontuacaoObtida = _criterio.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }

        [Fact]
        public void Nao_deve_pontuar_quando_familia_nao_atender_ao_criterio()
        {
            const int pontuacaoEsperada = 0;
            var dependenteMenorDeIdadeUm = PessoaBuilder.UmaPessoa()
                .ComTipo(TipoDePessoa.Dependente)
                .ComDataDeNascimento(new DateTime(2006, 12, 1))
                .Build();
            var dependenteMenorDeIdadeDois = PessoaBuilder.UmaPessoa()
                .ComTipo(TipoDePessoa.Dependente)
                .ComDataDeNascimento(new DateTime(2005, 12, 1))
                .Build();
            var dependenteMenorDeIdadeTres = PessoaBuilder.UmaPessoa()
                .ComTipo(TipoDePessoa.Dependente)
                .ComDataDeNascimento(new DateTime(2001, 12, 1))
                .Build();
            var pretendente = PessoaBuilder.UmaPessoa().ComTipo(TipoDePessoa.Pretendete).Build();
            var pessoas = new[]
                {dependenteMenorDeIdadeUm, dependenteMenorDeIdadeDois, dependenteMenorDeIdadeTres, pretendente};
            var familia = FluentBuilder<Familia>.New()
                .WithCollection(f => f.Pessoas, pessoas)
                .Build();

            var pontuacaoObtida = _criterio.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }
    }
}