using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using DesafioSelecao.TesteDeUnidade.Builders;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio.Criterios
{
    public class CriterioDeRendaEntre1501Ah2000Teste
    {
        private readonly CriterioDeRendaEntre1501Ah2000 _criterio;
        private readonly Pessoa _pessoaUm;
        private readonly Pessoa _pessoaDois;
        private readonly Familia _familia;

        public CriterioDeRendaEntre1501Ah2000Teste()
        {
            _criterio = new CriterioDeRendaEntre1501Ah2000();
            _pessoaUm = PessoaBuilder.UmaPessoa().Build();
            _pessoaDois = PessoaBuilder.UmaPessoa().Build();
            var pessoas = new[] { _pessoaUm, _pessoaDois };
            _familia = FluentBuilder<Familia>.New()
                .WithCollection(f => f.Pessoas, pessoas).Build();
        }

        [Theory]
        [InlineData(1501, 0)]
        [InlineData(1500, 200)]
        [InlineData(500, 1500)]
        [InlineData(0, 2000)]
        public void Deve_pontuar_familia_quando_criterio_for_atendido(decimal valorDaRendaDaPessoaUm,
            decimal valorDaRendaDaPessoaDois)
        {
            const int pontuacaoEsperada = 1;
            var rendaDaPessoaUm = RendaBuilder.UmaRenda().ComValor(valorDaRendaDaPessoaUm).Build();
            var rendaDaPessoaDois = RendaBuilder.UmaRenda().ComValor(valorDaRendaDaPessoaDois).Build();
            _pessoaUm.Adicionar(rendaDaPessoaUm);
            _pessoaDois.Adicionar(rendaDaPessoaDois);

            var pontuacaoObtida = _criterio.EhAtendidoPela(_familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1500)]
        [InlineData(1500, 501)]
        [InlineData(2001, 0)]
        [InlineData(5000, 500)]
        public void Nao_deve_pontuar_familia_quando_criterio_nao_for_atendido(decimal valorDaRendaDaPessoaUm,
            decimal valorDaRendaDaPessoaDois)
        {
            const int pontuacaoEsperada = 0;
            var rendaDaPessoaUm = RendaBuilder.UmaRenda().ComValor(valorDaRendaDaPessoaUm).Build();
            var rendaDaPessoaDois = RendaBuilder.UmaRenda().ComValor(valorDaRendaDaPessoaDois).Build();
            _pessoaUm.Adicionar(rendaDaPessoaUm);
            _pessoaDois.Adicionar(rendaDaPessoaDois);

            var pontuacaoObtida = _criterio.EhAtendidoPela(_familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }
    }
}