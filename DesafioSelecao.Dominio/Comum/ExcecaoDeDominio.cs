using System;

namespace DesafioSelecao.Dominio.Comum
{
    public class ExcecaoDeDominio : Exception
    {
        public ExcecaoDeDominio(string message) : base(message) { }
    }
}