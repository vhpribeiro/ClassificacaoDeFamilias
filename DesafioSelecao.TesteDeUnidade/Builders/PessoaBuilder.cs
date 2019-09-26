using System;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.TesteDeUnidade.Builders
{
    public class PessoaBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _nome = "Vitor Hugo Pereira Ribeiro";
        private TipoDePessoa _tipo = TipoDePessoa.Pretendete;
        private DateTime _dataDeNascimento = DateTime.Now;
        private Renda _renda = RendaBuilder.UmaRenda().Build();

        public static PessoaBuilder UmaPessoa()
        {
            return new PessoaBuilder();
        }

        public PessoaBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }

        public PessoaBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public PessoaBuilder ComTipo(TipoDePessoa tipo)
        {
            _tipo = tipo;
            return this;
        }

        public PessoaBuilder ComDataDeNascimento(DateTime dataDeNascimento)
        {
            _dataDeNascimento = dataDeNascimento;
            return this;
        }

        public PessoaBuilder ComRenda(Renda renda)
        {
            _renda = renda;
            return this;
        }

        public Pessoa Build()
        {
            return new Pessoa(_id, _nome, _tipo, _dataDeNascimento);
        }
    }
}