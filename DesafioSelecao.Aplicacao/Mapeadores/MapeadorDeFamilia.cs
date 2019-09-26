using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.Aplicacao.Mapeadores
{
    public class MapeadorDeFamilia
    {
        public static Familia Mapear(FamiliaDto familiaDto)
        {
            return new Familia(familiaDto.Id, familiaDto.Status);
        }
    }
}