using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDePretendenteComIdadeIgualOuMaiorA45Anos : Criterio
    {
        private const int Pontos = 3;

        public override int EhAtendidoPela(Familia familia)
        {
            var pretendente = familia.Pessoas.First(p => p.Tipo == TipoDePessoa.Pretendete);
            return pretendente.Idade >= 45 ? Pontos : 0;
        }
    }
}