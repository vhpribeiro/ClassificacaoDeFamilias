using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDeRendaInferiorA900: Criterio
    {
        public int Pontos => 5;
        public override int EhAtendidoPela(Familia familia)
        {
            var rendaTotalDaFamilia = familia.Pessoas.Sum(p => p.Renda.Valor);
            return rendaTotalDaFamilia <= 900 ? Pontos : 0;
        }
    }
}