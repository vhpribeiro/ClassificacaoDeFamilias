using System;
using DesafioSelecao.Aplicacao;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using Moq;
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

        public ClassificacaoDeFamiliasTestes()
        {
            _criterioRepositorio = new Mock<ICriterioRepositorio>();
            _classificacaoDeFamilias = new ClassificacaoDeFamilias(_criterioRepositorio.Object);
            var id = Guid.NewGuid();
            const Status status = Status.CadastroValido;
            var pessoaUmDto = new PessoaDto
            {
                DataDeNascimento = new DateTime(1997, 07, 03),
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
            var pessoaTresDto = new PessoaDto
            {
                DataDeNascimento = new DateTime(1999, 06, 17),
                Id = id,
                Nome = "Karina",
                Tipo = TipoDePessoa.Pretendete
            };
            var pessoasDaFamiliaUm = new[] { pessoaDoisDto, pessoaUmDto };
            var rendaUmDto = new RendaDto { IdPessoa = id, Valor = 500 };
            var rendaDoisDto = new RendaDto { IdPessoa = id, Valor = 800 };
            var rendasDaFamiliaUm = new[] { rendaDoisDto, rendaUmDto };
            _familiaUm = new FamiliaDto
            {
                Id = id,
                Pessoas = pessoasDaFamiliaUm,
                Rendas = rendasDaFamiliaUm,
                Status = status
            };
            var pessoasDaFamiliaDois = new[] { pessoaTresDto };
            var rendasDaFamiliaDois = new[] { rendaUmDto };
            _familiaDois = new FamiliaDto
            {
                Id = id,
                Pessoas = pessoasDaFamiliaDois,
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
    }
}