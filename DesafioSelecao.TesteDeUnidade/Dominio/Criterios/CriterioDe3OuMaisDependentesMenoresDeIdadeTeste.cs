using System;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using DesafioSelecao.TesteDeUnidade.Builders;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio.Criterios
{
    public class CriterioDe3OuMaisDependentesMenoresDeIdadeTeste
    {
        private readonly CriterioDe3OuMaisDependentesMenoresDeIdade _criterio;

        public CriterioDe3OuMaisDependentesMenoresDeIdadeTeste()
        {
            _criterio = new CriterioDe3OuMaisDependentesMenoresDeIdade();
        }

        [Fact]
        public void Deve_pontuar_familia_quando_criterio_for_atendido()
        {
            const int pontuacaoEsperada = 3;
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
                .ComDataDeNascimento(new DateTime(2010, 12, 1))
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
                .ComDataDeNascimento(new DateTime(2000, 12, 1))
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