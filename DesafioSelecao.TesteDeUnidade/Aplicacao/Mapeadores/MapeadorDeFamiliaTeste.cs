using System;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Aplicacao.Mapeadores;
using DesafioSelecao.Dominio;
using ExpectedObjects;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Aplicacao.Mapeadores
{
    public class MapeadorDeFamiliaTeste
    {
        [Fact]
        public void Deve_mapear_uma_familia()
        {
            var id = Guid.NewGuid();
            const Status status = Status.CadastroValido;
            var pessoaUmDto = new PessoaDto
            {
                DataDeNascimento = new DateTime(1997,07,03),
                Id = id,
                Nome = "Maria",
                Tipo = TipoDePessoa.Conjuge
            };
            var pessoaDoisDto = new PessoaDto
            {
                DataDeNascimento = new DateTime(1996, 06, 17),
                Id = id,
                Nome = "João",
                Tipo = TipoDePessoa.Pretendete
            };
            var pessoas = new[] {pessoaDoisDto, pessoaUmDto};
            var rendaUmDto = new RendaDto{IdPessoa = id, Valor = 500};
            var rendaDoisDto = new RendaDto { IdPessoa = id, Valor = 800 };
            var rendas = new[] {rendaDoisDto, rendaUmDto};
            var familiaDto = new FamiliaDto
            {
                Id = id,
                Pessoas = pessoas,
                Rendas = rendas, 
                Status = status
            };
            var familiaEsperada = new
            {
                Id = id,
                Status = status
            };

            var familiaObtida = MapeadorDeFamilia.Mapear(familiaDto);

            familiaEsperada.ToExpectedObject().ShouldMatch(familiaObtida);
        }

        [Fact]
        public void Deve_mapear_uma_familia_contemplada()
        {
            var idFamilia = new Guid("12345678-1234-4567-8901-012345678912");
            const int quantidadeDeCriteriosAtendidos = 4;
            const int pontuacao = 12;
            var familia = FluentBuilder<Familia>.New()
                .With(f => f.QuantidadeDeCriteriosAtendidos, quantidadeDeCriteriosAtendidos)
                .With(f => f.Pontuacao, pontuacao)
                .With(f => f.Id, idFamilia)
                .Build();
            var familiaContempladaEsperada = new FamiliaContempladaDto
            {
                Id = idFamilia,
                QuantidadeDeCriteriosAtendidos = quantidadeDeCriteriosAtendidos,
                PontuacaoTotal = pontuacao,
                DataDaSelecao = DateTime.Now.Date
            };

            var familiaContempladaObtida = MapeadorDeFamilia.MapearFamiliaContemplada(familia);

            familiaContempladaEsperada.ToExpectedObject().ShouldMatch(familiaContempladaObtida);
        }
    }
}