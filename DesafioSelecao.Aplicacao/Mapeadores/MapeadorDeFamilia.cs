using System.Linq;
using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.Aplicacao.Mapeadores
{
    public class MapeadorDeFamilia
    {
        public static Familia Mapear(FamiliaDto familiaDto)
        {
            var pessoas = familiaDto.Pessoas.Select(MapeadorDePessoa.Mapear).ToList();
            foreach (var rendaDto in familiaDto.Rendas)
            {
                var renda = MapeadorDeRenda.Mapear(rendaDto.Valor);
                var pessoaQueDeveTerRendaAdicionada = pessoas.First(p => p.Id == rendaDto.IdPessoa);
                pessoaQueDeveTerRendaAdicionada.Adicionar(renda);
            }

            var familia = new Familia(familiaDto.Id, familiaDto.Status);

            foreach (var pessoa in pessoas)
                familia.Adicionar(pessoa);

            return familia;
        }
    }
}