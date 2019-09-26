using System.Linq;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.Aplicacao.Mapeadores
{
    public class MapeadorDeFamilia
    {
        public static Familia Mapear(FamiliaDto familiaDto)
        {
            var familia = new Familia(familiaDto.Id, familiaDto.Status);
            var pessoas = familiaDto.Pessoas.Select(MapeadorDePessoa.Mapear);

            foreach (var pessoa in pessoas)
                familia.Adicionar(pessoa);

            foreach (var rendaDto in familiaDto.Rendas)
            {
                var renda = MapeadorDeRenda.Mapear(rendaDto.Valor);
                var pessoaQueDeveTerRendaAdicionada = pessoas.First(p => p.Id == rendaDto.IdPessoa);
                pessoaQueDeveTerRendaAdicionada.Adicionar(renda);
            }

            return familia;
        }
    }
}