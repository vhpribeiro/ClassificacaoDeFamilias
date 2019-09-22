using DesafioSelecao.Dominio;

namespace DesafioSelecao.Aplicacao.Mapeadores
{
    public class MapeadorDeRenda
    {
        public static Renda Mapear(decimal valorDaRenda)
        {
            return new Renda(valorDaRenda);
        }
    }
}