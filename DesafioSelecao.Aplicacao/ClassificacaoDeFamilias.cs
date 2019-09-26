using System.Linq;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Aplicacao.Mapeadores;
using DesafioSelecao.Dominio;
using DesafioSelecao.Dominio.Criterios;

namespace DesafioSelecao.Aplicacao
{
    public class ClassificacaoDeFamilias
    {
        private readonly ICriterioRepositorio _criterioRepositorio;

        public ClassificacaoDeFamilias(ICriterioRepositorio criterioRepositorio)
        {
            _criterioRepositorio = criterioRepositorio;
        }

        public void Classificar(FamiliaDto[] familiasDto)
        {
            var criterios = _criterioRepositorio.ObterTodos();
            var familias = familiasDto.Select(MapeadorDeFamilia.Mapear);
            var pontuadorDeFamilias = new PontuacaoDeFamilias();

            foreach (var familia in familias)
            {
                foreach (var criterio in criterios)
                {
                    pontuadorDeFamilias.Pontuar(criterio, familia);
                }
            }
        }
    }
}