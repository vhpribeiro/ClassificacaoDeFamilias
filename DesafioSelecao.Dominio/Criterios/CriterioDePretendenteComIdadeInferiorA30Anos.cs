using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDePretendenteComIdadeInferiorA30Anos : Criterio
    {
        public int Pontos => 1;

        public override int EhAtendidoPela(Familia familia)
        {
            var pretendente = familia.Pessoas.FirstOrDefault(p => p.Tipo == TipoDePessoa.Pretendete);
            return pretendente.Idade < 30 ? Pontos : 0;
        }
    }
}