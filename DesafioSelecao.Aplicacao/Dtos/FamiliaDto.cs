using System;
using System.Collections.Generic;
using DesafioSelecao.Dominio;

namespace DesafioSelecao.Aplicacao.Dtos
{
    public class FamiliaDto
    {
        public Guid Id { get; set; }
        public IEnumerable<PessoaDto> Pessoas { get; set; }
        public Status Status { get; set; }
        public IEnumerable<RendaDto> Rendas {get; set; }
    }
}