using DesafioSelecao.Dominio.Criterios;

namespace DesafioSelecao.Dominio
{
    public class GerenciamentoDeClassificacaoDeFamilias
    {
        public void Gerenciar(Criterio criterio, Familia familia)
        {
            if (criterio.EhAtendidoPela(familia) <= 0) return;

            familia.Pontuacao += criterio.EhAtendidoPela(familia);
            familia.QuantidadeDeCriteriosAtendidos++;
        }
    }
}