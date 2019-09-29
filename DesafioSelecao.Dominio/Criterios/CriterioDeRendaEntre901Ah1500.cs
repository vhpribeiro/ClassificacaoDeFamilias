using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDeRendaEntre901Ah1500 : Criterio
    {
        public int Pontos => 3;
        public override int EhAtendidoPela(Familia familia)
        {
            var totalDaRendaDaFamilia = familia.Pessoas.Sum(p => p.Renda.Valor);
            return totalDaRendaDaFamilia >= 901 && totalDaRendaDaFamilia <= 1500 ? Pontos : 0;
        }
    }
}