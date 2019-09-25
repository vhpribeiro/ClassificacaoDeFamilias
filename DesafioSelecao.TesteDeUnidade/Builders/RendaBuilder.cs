using DesafioSelecao.Dominio;

namespace DesafioSelecao.TesteDeUnidade.Builders
{
    public class RendaBuilder
    {
        private decimal _valor = 100;

        public static RendaBuilder UmaRenda()
        {
            return new RendaBuilder();
        }

        public RendaBuilder ComValor(decimal valor)
        {
            _valor = valor;
            return this;
        }

        public Renda Build()
        {
            return new Renda(_valor);
        }
    }
}