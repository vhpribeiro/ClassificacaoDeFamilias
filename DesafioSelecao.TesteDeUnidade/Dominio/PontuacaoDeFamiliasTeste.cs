using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio
{
    public class PontuacaoDeFamiliasTeste
    {
        [Fact]
        public void Deve_somar_a_pontuacao_da_familia_e_aumentar_quantidade_de_criterios_atendidos_quando_ela_atender_o_criterio()
        {
            const int quantidadeDeCriteriosInicialmenteAtendidos = 1;
            const int pontuacaoInicialDaFamilia = 4;
            const int valorDaRendaUm = 400;
            const int valorDaRendaDois = 500;
            var rendaDaPessoaUm = FluentBuilder<Renda>.New().With(renda => renda.Valor, valorDaRendaUm).Build();
            var rendaDaPessoaDois = FluentBuilder<Renda>.New().With(renda => renda.Valor, valorDaRendaDois).Build();
            var pessoaUm = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Renda, rendaDaPessoaUm).Build();
            var pessoaDois = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Renda, rendaDaPessoaDois).Build();
            var pessoas = new[] { pessoaUm, pessoaDois };
            var familia = FluentBuilder<Familia>.New()
                .With(f => f.QuantidadeDeCriteriosAtendidos, quantidadeDeCriteriosInicialmenteAtendidos)
                .With(f => f.Pontuacao, pontuacaoInicialDaFamilia)
                .WithCollection(f => f.Pessoas, pessoas).Build();
            var criterioDeRendaInferiorA900 = new CriterioDeRendaInferiorA900();
            var pontuacaoDeFamilias = new PontuacaoDeFamilias();
            var pontuacaoDaFamiliaEsperada = pontuacaoInicialDaFamilia + criterioDeRendaInferiorA900.Pontos;
            const int quantidadeDeCriteriosAtendidosEsperados = quantidadeDeCriteriosInicialmenteAtendidos + 1;

            pontuacaoDeFamilias.Pontuar(criterioDeRendaInferiorA900, familia);

            Assert.Equal(pontuacaoDaFamiliaEsperada, familia.Pontuacao);
            Assert.Equal(quantidadeDeCriteriosAtendidosEsperados, familia.QuantidadeDeCriteriosAtendidos);
        }

        [Fact]
        public void 
            Nao_deve_alterar_a_pontuacao_da_familia_e_nem_alterar_quantidade_de_criterios_atendidos_quando_ela_nao_atender_o_criterio()
        {
            const int quantidadeDeCriteriosInicialmenteAtendidos = 1;
            const int pontuacaoInicialDaFamilia = 4;
            const int valorDaRendaUm = 400;
            const int valorDaRendaDois = 800;
            var rendaDaPessoaUm = FluentBuilder<Renda>.New().With(renda => renda.Valor, valorDaRendaUm).Build();
            var rendaDaPessoaDois = FluentBuilder<Renda>.New().With(renda => renda.Valor, valorDaRendaDois).Build();
            var pessoaUm = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Renda, rendaDaPessoaUm).Build();
            var pessoaDois = FluentBuilder<Pessoa>.New().With(pessoa => pessoa.Renda, rendaDaPessoaDois).Build();
            var pessoas = new[] { pessoaUm, pessoaDois };
            var familia = FluentBuilder<Familia>.New()
                .With(f => f.QuantidadeDeCriteriosAtendidos, quantidadeDeCriteriosInicialmenteAtendidos)
                .With(f => f.Pontuacao, pontuacaoInicialDaFamilia)
                .WithCollection(f => f.Pessoas, pessoas).Build();
            var criterioDeRendaInferiorA900 = new CriterioDeRendaInferiorA900();
            var pontuacaoDeFamilias = new PontuacaoDeFamilias();

            pontuacaoDeFamilias.Pontuar(criterioDeRendaInferiorA900, familia);

            Assert.Equal(pontuacaoInicialDaFamilia, familia.Pontuacao);
            Assert.Equal(quantidadeDeCriteriosInicialmenteAtendidos, familia.QuantidadeDeCriteriosAtendidos);
        }
    }
}