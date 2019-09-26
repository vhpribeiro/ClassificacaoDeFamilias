using System;
using System.Linq;
using DesafioSelecao.Dominio;
using DesafioSelecao.TesteDeUnidade.Builders;
using ExpectedObjects;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio
{
    public class FamiliaTeste
    {
        [Fact]
        public void Deve_criar_uma_familia()
        {
            var id = Guid.NewGuid();
            const Status status = Status.CadastroValido;
            var familiaEsperada = new
            {
                Id = id,
                Status = status,
                QuantidadeDeCriteriosAtendidos = 0,
                Pontuacao = 0
            };

            var familiaObtida = new Familia(id, status);

            familiaEsperada.ToExpectedObject().ShouldMatch(familiaObtida);
        }

        [Fact]
        public void Deve_adicionar_pessoa_na_familia()
        {
            const int quantidadeDePessoasEsperadas = 1;
            var familia = FamiliaBuilder.UmaFamilia().Build();
            var pessoa = PessoaBuilder.UmaPessoa().Build();

            familia.Adicionar(pessoa);

            var quantidadeDePessoasObtidas = familia.Pessoas.Count();
            Assert.Equal(quantidadeDePessoasEsperadas, quantidadeDePessoasObtidas);
        }
    }
}