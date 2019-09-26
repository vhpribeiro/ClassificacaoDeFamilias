using DesafioSelecao.Aplicacao.Dtos;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.Aplicacao.Mapeadores
{
    public class MapeadorDePessoa
    {
        public static Pessoa Mapear(PessoaDto pessoaDto)
        {
            return new Pessoa(pessoaDto.Id, pessoaDto.Nome, pessoaDto.Tipo, pessoaDto.DataDeNascimento);
        }
    }
}