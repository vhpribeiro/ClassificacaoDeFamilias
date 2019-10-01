using System.Collections.Generic;
using DesafioSelecao.Aplicacao.Dtos;

namespace DesafioSelecao.Infra.Comunicacoes
{
    public interface IComunicacaoComContemplados
    {
        void Contemplar(IEnumerable<FamiliaContempladaDto> familias);
    }
}