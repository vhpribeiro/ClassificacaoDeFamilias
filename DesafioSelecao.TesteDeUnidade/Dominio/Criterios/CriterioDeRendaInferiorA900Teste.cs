using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio.Criterios
{
    public class CriterioDeRendaInferiorA900Teste
    {
        private readonly CriterioDeRendaInferiorA900 _criterioDeRendaInferiorA900;

        public CriterioDeRendaInferiorA900Teste()
        {
            _criterioDeRendaInferiorA900 = new CriterioDeRendaInferiorA900();
        }

        [Theory]
        [InlineData(300, 600)]
        [InlineData(300, 400)]
        [InlineData(0, 0)]
        public void Deve_pontuar_cinco_pontos_quando_atender_ao_criterio(decimal valorDaRendaUm, decimal valorDaRendaDois)
        {
            const int pontuacaoEsperada = 5;
            var rendaDaPessoaUm = FluentBuilder<Renda>.New().With(renda => renda.Valor, valorDaRendaUm).Build();
            var rendaDaPessoaDois = FluentBuilder<Renda>.New().With(renda => renda.Valor, valorDaRendaDois).Build();
            var pessoaUm = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Renda, rendaDaPessoaUm).Build();
            var pessoaDois = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Renda, rendaDaPessoaDois).Build();
            var pessoas = new[] {pessoaUm, pessoaDois};
            var familia = FluentBuilder<Familia>.New().WithCollection(f => f.Pessoas, pessoas).Build();

            var pontuacaoObtida = _criterioDeRendaInferiorA900.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }

        [Theory]
        [InlineData(3000, 6000)]
        [InlineData(300, 601)]
        [InlineData(901, 0)]
        public void Nao_deve_pontuar_cinco_pontos_quando_atender_ao_criterio(decimal valorDaRendaUm, decimal valorDaRendaDois)
        {
            const int pontuacaoEsperada = 0;
            var rendaDaPessoaUm = FluentBuilder<Renda>.New().With(renda => renda.Valor, valorDaRendaUm).Build();
            var rendaDaPessoaDois = FluentBuilder<Renda>.New().With(renda => renda.Valor, valorDaRendaDois).Build();
            var pessoaUm = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Renda, rendaDaPessoaUm).Build();
            var pessoaDois = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Renda, rendaDaPessoaDois).Build();
            var pessoas = new[] { pessoaUm, pessoaDois };
            var familia = FluentBuilder<Familia>.New().WithCollection(f => f.Pessoas, pessoas).Build();

            var pontuacaoObtida = _criterioDeRendaInferiorA900.EhAtendidoPela(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoObtida);
        }
    }
}