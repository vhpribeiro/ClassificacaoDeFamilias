using DesafioSelecao.Dominio.Criterios;

namespace DesafioSelecao.Dominio
{
    public class PontuacaoDeFamilias
    {
        public void Pontuar(Criterio criterio, Familia familia)
        {
            if (criterio.EhAtendidoPela(familia) <= 0) return;

            familia.Pontuacao += criterio.EhAtendidoPela(familia);
            familia.QuantidadeDeCriteriosAtendidos++;
        }
    }
}