using System;
using System.Collections.Generic;

namespace DesafioSelecao.Dominio
{
    public class Familia
    {
        public Guid Id { get; protected set; }
        private readonly IList<Pessoa> _pessoas;
        public IEnumerable<Pessoa> Pessoas => _pessoas;
        public Status Status { get; protected set; }
    }
}