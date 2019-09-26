using System;
using System.Collections.Generic;

namespace DesafioSelecao.Dominio
{
    public class Familia
    {
        public Guid Id { get; protected set; }
        public Status Status { get; protected set; }
        public int QuantidadeDeCriteriosAtendidos { get; protected internal set; }
        public int Pontuacao { get; protected internal set; }
        private readonly IList<Pessoa> _pessoas = new List<Pessoa>();
        public IEnumerable<Pessoa> Pessoas => _pessoas;

        public Familia(Guid id, Status status)
        {
            Id = id;
            Status = status;
            QuantidadeDeCriteriosAtendidos = 0;
            Pontuacao = 0;
        }

        public void Adicionar(Pessoa pessoa)
        {
            _pessoas.Add(pessoa);
        }
    }
}