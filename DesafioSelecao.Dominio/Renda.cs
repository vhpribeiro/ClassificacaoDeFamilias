namespace DesafioSelecao.Dominio
{
    public class Renda
    {
        public decimal Valor { get; protected set; }

        public Renda(decimal valor)
        {
            Valor = valor;
        }
    }
}