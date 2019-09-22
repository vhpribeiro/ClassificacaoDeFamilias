using System;
using System.Collections.Generic;

namespace DesafioSelecao.Dominio
{
    public class Familia
    {
        public Guid Id { get; protected set; }
        public int QuantidadeDeCriteriosAtendidos { get; protected internal set; }
        public Status Status { get; protected set; }
        public int Pontuacao { get; protected internal set; }
        private readonly IList<Pessoa> _pessoas;
        public IEnumerable<Pessoa> Pessoas => _pessoas;
    }
}