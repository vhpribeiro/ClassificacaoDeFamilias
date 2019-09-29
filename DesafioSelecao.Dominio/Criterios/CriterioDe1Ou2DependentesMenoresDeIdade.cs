using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDe1Ou2DependentesMenoresDeIdade : Criterio
    {
        public int Pontos => 2;

        public override int EhAtendidoPela(Familia familia)
        {
            var quantidadeDeDependentesMenoresDeIdade =
                familia.Pessoas.Count(p => p.Tipo == TipoDePessoa.Dependente && p.Idade < 18);
            return quantidadeDeDependentesMenoresDeIdade >= 1 && quantidadeDeDependentesMenoresDeIdade <= 2 ? Pontos : 0;
        }
    }
}