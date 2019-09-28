using System.Collections.Generic;
using System.Linq;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Aplicacao.Mapeadores;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;

namespace DesafioSelecao.Aplicacao
{
    public class ClassificacaoDeFamilias : IClassificacaoDeFamilias
    {
        private readonly ICriterioRepositorio _criterioRepositorio;

        public ClassificacaoDeFamilias(ICriterioRepositorio criterioRepositorio)
        {
            _criterioRepositorio = criterioRepositorio;
        }

        public IEnumerable<Familia> Classificar(FamiliaDto[] familiasDto)
        {
            var criterios = _criterioRepositorio.ObterTodos();
            var familias = familiasDto.Where(f => f.Status == Status.CadastroValido).Select(MapeadorDeFamilia.Mapear).ToList();
            var pontuadorDeFamilias = new PontuacaoDeFamilias();

            foreach (var familia in familias)
            {
                foreach (var criterio in criterios)
                {
                    pontuadorDeFamilias.Pontuar(criterio, familia);
                }
            }

            return familias;
        }
    }
}