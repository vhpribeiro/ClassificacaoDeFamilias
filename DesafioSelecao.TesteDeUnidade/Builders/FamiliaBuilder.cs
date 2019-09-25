using System;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.TesteDeUnidade.Builders
{
    public class FamiliaBuilder
    {
        private Guid _id = Guid.NewGuid();
        private Status _status = Status.CadastroValido;

        public static FamiliaBuilder UmaFamilia()
        {
            return new FamiliaBuilder();
        }

        public FamiliaBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }

        public FamiliaBuilder ComStatus(Status status)
        {
            _status = status;
            return this;
        }

        public Familia Build()
        {
            return new Familia(_id, _status);
        }
    }
}