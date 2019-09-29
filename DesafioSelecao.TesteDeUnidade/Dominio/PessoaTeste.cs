using System;
using DesafioSelecao.Dominio;
using DesafioSelecao.TesteDeUnidade.Builders;
using ExpectedObjects;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Dominio
{
    public class PessoaTeste
    {
        [Fact]
        public void Deve_criar_uma_pessoa()
        {
            var id = Guid.NewGuid();
            DateTime dataDeNascimento = new DateTime(1996, 06, 17);
            const string nome = "Vitor";
            const TipoDePessoa tipo = TipoDePessoa.Pretendete;
            var pessoaEsperada = new
            {
                Id = id,
                DataDeNascimento = dataDeNascimento,
                Nome = nome,
                Tipo = tipo,
                Idade = 23
            };

            var pessoaObtida = new Pessoa(id, nome, tipo, dataDeNascimento);

            pessoaEsperada.ToExpectedObject().ShouldMatch(pessoaObtida);
        }

        [Fact]
        public void Deve_adicionar_renda_a_uma_pessoa()
        {
            var rendaEsperada = RendaBuilder.UmaRenda().Build();
            var pessoa = PessoaBuilder.UmaPessoa().Build();

            pessoa.Adicionar(rendaEsperada);

            rendaEsperada.ToExpectedObject().ShouldMatch(pessoa.Renda);
        }
    }
}