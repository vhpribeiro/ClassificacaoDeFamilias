using DesafioSelecao.Aplicacao.Mapeadores;
using DesafioSelecao.Dominio;
using ExpectedObjects;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Aplicacao.Mapeadores
{
    public class MapeadorDeRendaTeste
    {
        [Fact]
        public void Deve_mapear_a_renda()
        {
            const decimal valorDaRenda = 900;
            var rendaEsperada = new Renda(valorDaRenda);

            var rendaObtida = MapeadorDeRenda.Mapear(valorDaRenda);

            rendaEsperada.ToExpectedObject().ShouldMatch(rendaObtida);
        }
    }
}