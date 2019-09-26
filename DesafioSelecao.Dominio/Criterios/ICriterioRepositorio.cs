using System.Collections.Generic;

namespace DesafioSelecao.Dominio.Criterios
{
    public interface ICriterioRepositorio
    {
        IEnumerable<Criterio> ObterTodos();
    }
}