using System;
using System.Linq;
using DesafioSelecao.Aplicacao;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Aplicacao.Mapeadores;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using DesafioSelecao.TesteDeUnidade.Builders;
using ExpectedObjects;
using Moq;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace DesafioSelecao.TesteDeUnidade.Aplicacao
{
    public class ClassificacaoDeFamiliasTestes
    {
        private readonly Mock<ICriterioRepositorio> _criterioRepositorio;
        private readonly ClassificacaoDeFamilias _classificacaoDeFamilias;
        private readonly FamiliaDto _familiaUm;
        private readonly FamiliaDto _familiaDois;
        private readonly CriterioDeRendaInferiorA900 _criterioDeRendaInferiorA900;
        private readonly CriterioDePretendenteComIdadeIgualOuMaiorA45Anos _criterioDePretendenteComIdedadeIgualOuMaiorA45Anos;
        private PessoaDto[] _pessoasDaFamiliaUm;
        private PessoaDto[] _pessoasDaFamiliaDois;
        private readonly Guid _idFamilia;
        private readonly PessoaDto _pessoaUmDto;
        private readonly PessoaDto _pessoaDoisDto;
        private readonly PessoaDto _pessoaTresDto;
        private readonly RendaDto _rendaUmDto;
        private readonly RendaDto _rendaDoisDto;
        private RendaDto _rendaTresDto;
        private readonly Guid _idFamiliaDois;

        public ClassificacaoDeFamiliasTestes()
        {
            _criterioRepositorio = new Mock<ICriterioRepositorio>();
            _classificacaoDeFamilias = new ClassificacaoDeFamilias(_criterioRepositorio.Object);
            _idFamilia = new Guid("12345678-1234-4567-8901-012345678912");
            _idFamiliaDois = new Guid("12345678-1234-4567-8901-012345678921");
            var idPessoaUm = new Guid("12345678-1234-4567-8901-012345679812");
            var idPessoaDois = new Guid("12345678-1234-4567-8901-102345678912");
            var idPessoaTres = new Guid("12345678-1234-4567-8901-012346578912");
            const Status status = Status.CadastroValido;
            _pessoaUmDto = new PessoaDto
            {
                DataDeNascimento = new DateTime(1997, 07, 03),
                Id = idPessoaUm,
                Nome = "Maria",
                Tipo = TipoDePessoa.Conjuge
            };
            _pessoaDoisDto = new PessoaDto
            {
                DataDeNascimento = new DateTime(1996, 06, 17),
                Id = idPessoaDois,
                Nome = "João",
                Tipo = TipoDePessoa.Pretendete
            };
            _pessoaTresDto = new PessoaDto
            {
                DataDeNascimento = new DateTime(1999, 06, 17),
                Id = idPessoaTres,
                Nome = "Karina",
                Tipo = TipoDePessoa.Pretendete
            };
            _pessoasDaFamiliaUm = new[] { _pessoaDoisDto, _pessoaUmDto };
            _rendaUmDto = new RendaDto { IdPessoa = idPessoaUm, Valor = 500 };
            _rendaDoisDto = new RendaDto { IdPessoa = idPessoaDois, Valor = 800 };
            _rendaTresDto = new RendaDto { IdPessoa = idPessoaTres, Valor = 500 };
            var rendasDaFamiliaUm = new[] { _rendaDoisDto, _rendaUmDto };
            _familiaUm = new FamiliaDto
            {
                Id = _idFamilia,
                Pessoas = _pessoasDaFamiliaUm,
                Rendas = rendasDaFamiliaUm,
                Status = status
            };
            _pessoasDaFamiliaDois = new[] { _pessoaTresDto };
            var rendasDaFamiliaDois = new[] { _rendaTresDto };
            _familiaDois = new FamiliaDto
            {
                Id = _idFamiliaDois,
                Pessoas = _pessoasDaFamiliaDois,
                Rendas = rendasDaFamiliaDois,
                Status = status
            };
            _criterioDeRendaInferiorA900 = new CriterioDeRendaInferiorA900();
            _criterioDePretendenteComIdedadeIgualOuMaiorA45Anos = new CriterioDePretendenteComIdadeIgualOuMaiorA45Anos();
        }

        [Fact]
        public void Deve_obter_todos_criterios()
        {
            var criterios = new Criterio[] {_criterioDeRendaInferiorA900, _criterioDePretendenteComIdedadeIgualOuMaiorA45Anos};
            var familiasDto = new[] {_familiaUm, _familiaDois};
            _criterioRepositorio.Setup(cr => cr.ObterTodos()).Returns(criterios);

            _classificacaoDeFamilias.Classificar(familiasDto);

            _criterioRepositorio.Verify(cr => cr.ObterTodos());
        }

        [Fact]
        public void Deve_classificar_as_familias()
        {
            var criterios = new Criterio[] { _criterioDeRendaInferiorA900, _criterioDePretendenteComIdedadeIgualOuMaiorA45Anos };
            var familiasDto = new[] { _familiaUm, _familiaDois };
            _criterioRepositorio.Setup(cr => cr.ObterTodos()).Returns(criterios);
            var rendaUm = MapeadorDeRenda.Mapear(_rendaUmDto.Valor);
            var rendaDois = MapeadorDeRenda.Mapear(_rendaDoisDto.Valor);
            var pessoaUm = MapeadorDePessoa.Mapear(_pessoaUmDto);
            var pessoaDois = MapeadorDePessoa.Mapear(_pessoaDoisDto);
            var familiaUm = FluentBuilder<Familia>.New()
                .With(f => f.QuantidadeDeCriteriosAtendidos, 0)
                .With(f => f.Pontuacao, 0)
                .With(f => f.Status, Status.CadastroValido)
                .With(f => f.Id, _idFamilia)
                .Build();
            pessoaUm.Adicionar(rendaUm);
            pessoaDois.Adicionar(rendaDois);
            familiaUm.Adicionar(pessoaUm);
            familiaUm.Adicionar(pessoaDois);
            var pessoaTres = MapeadorDePessoa.Mapear(_pessoaTresDto);
            var familiaDois = FluentBuilder<Familia>.New()
                .With(f => f.QuantidadeDeCriteriosAtendidos, 1)
                .With(f => f.Pontuacao, 5)
                .With(f => f.Status, Status.CadastroValido)
                .With(f => f.Id, _idFamiliaDois)
                .Build();
            pessoaTres.Adicionar(rendaUm);
            familiaDois.Adicionar(pessoaTres);
            var familiasEsperadas = new[]
            {
                familiaUm,
                familiaDois
            };

            var familiasObtidas = _classificacaoDeFamilias.Classificar(familiasDto);

            familiasEsperadas.ToExpectedObject().ShouldMatch(familiasObtidas);
        }

        [Theory]
        [InlineData(Status.CadastroIncompleto)]
        [InlineData(Status.JaPossuiUmaCasa)]
        [InlineData(Status.SelecionadaEmOutroProcesso)]
        public void Nao_deve_conter_nenhuma_familia_classificada_com_status_invalido(Status statusInvalido)
        {
            const int quantidadeDeFamiliasInvalidasEsperadas = 0;
            var criterios = new Criterio[] { _criterioDeRendaInferiorA900, _criterioDePretendenteComIdedadeIgualOuMaiorA45Anos };
            _familiaUm.Status = statusInvalido;
            var familiasDto = new[] { _familiaUm, _familiaDois };
            _criterioRepositorio.Setup(cr => cr.ObterTodos()).Returns(criterios);

            var familiasObtidas = _classificacaoDeFamilias.Classificar(familiasDto);

            var quantidadeDeFamiliasInvalidasObtidas = familiasObtidas.Count(f => f.Status == statusInvalido);
            Assert.Equal(quantidadeDeFamiliasInvalidasEsperadas, quantidadeDeFamiliasInvalidasObtidas);
        }
    }
}