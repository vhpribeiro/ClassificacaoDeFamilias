using System.Collections.Generic;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.Aplicacao
{
    public interface IClassificacaoDeFamilias
    {
        IEnumerable<Familia> Classificar(FamiliaDto[] familiasDto);
    }
}