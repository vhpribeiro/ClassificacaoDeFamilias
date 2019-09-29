using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDeRendaEntre1501Ah2000 : Criterio
    {
        public int Pontos => 1;

        public override int EhAtendidoPela(Familia familia)
        {
            var rendaTotalDaFamilia = familia.Pessoas.Sum(p => p.Renda.Valor);
            return rendaTotalDaFamilia >= 1501 && rendaTotalDaFamilia <= 2000 ? Pontos : 0;
        }
    }
}