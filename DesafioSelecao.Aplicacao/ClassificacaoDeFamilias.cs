using System.Collections.Generic;
using System.Linq;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Aplicacao.Mapeadores;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;
using DesafioSelecao.Infra.Comunicacoes;

namespace DesafioSelecao.Aplicacao
{
    public class ClassificacaoDeFamilias : IClassificacaoDeFamilias
    {
        private readonly ICriterioRepositorio _criterioRepositorio;
        private readonly IComunicacaoComContemplados _comunicacaoComContemplados;

        public ClassificacaoDeFamilias(ICriterioRepositorio criterioRepositorio,
            IComunicacaoComContemplados comunicacaoComContemplados)
        {
            _criterioRepositorio = criterioRepositorio;
            _comunicacaoComContemplados = comunicacaoComContemplados;
        }

        public IEnumerable<Familia> Classificar(FamiliaDto[] familiasDto)
        {
            var criterios = _criterioRepositorio.ObterTodos();
            var familias = familiasDto.Where(f => f.Status == Status.CadastroValido)
                .Select(MapeadorDeFamilia.Mapear).ToList();
            var pontuadorDeFamilias = new PontuacaoDeFamilias();

            foreach (var familia in familias)
                foreach (var criterio in criterios)
                    pontuadorDeFamilias.Pontuar(criterio, familia);

            var familiasOrdenadasPorPontuacao = familias.OrderByDescending(f => f.Pontuacao).ToList();
            EnviarParaOContemplados(familiasOrdenadasPorPontuacao);
            return familiasOrdenadasPorPontuacao;
        }

        private void EnviarParaOContemplados(List<Familia> familiasOrdenadasPorPontuacao)
        {
            var familiasContempladas = familiasOrdenadasPorPontuacao.Select(MapeadorDeFamilia.MapearFamiliaContemplada).ToList();
            _comunicacaoComContemplados.Contemplar(familiasContempladas);
        }
    }
}