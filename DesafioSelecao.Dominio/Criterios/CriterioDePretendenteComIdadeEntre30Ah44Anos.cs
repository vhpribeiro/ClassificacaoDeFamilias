using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDePretendenteComIdadeEntre30Ah44Anos : Criterio
    {
        public int Pontos => 2;

        public override int EhAtendidoPela(Familia familia)
        {
            var pretendente = familia.Pessoas.FirstOrDefault(p => p.Tipo == TipoDePessoa.Pretendete);
            return pretendente.Idade >= 30 && pretendente.Idade <= 44 ? Pontos : 0;
        }
    }
}