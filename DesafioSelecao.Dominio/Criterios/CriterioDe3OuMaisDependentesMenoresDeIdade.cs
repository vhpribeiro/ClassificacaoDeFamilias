using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDe3OuMaisDependentesMenoresDeIdade : Criterio
    {
        public int Pontos => 3;

        public override int EhAtendidoPela(Familia familia)
        {
            var quantidadeDeDependentesMenoresDeIdade =
                familia.Pessoas.Count(p => p.Tipo == TipoDePessoa.Dependente && p.Idade < 18);
            return quantidadeDeDependentesMenoresDeIdade >= 3 ? Pontos : 0;
        }
    }
}