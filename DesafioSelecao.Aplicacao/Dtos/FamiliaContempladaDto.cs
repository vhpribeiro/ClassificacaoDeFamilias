using System;

namespace DesafioSelecao.Aplicacao.Dtos
{
    public class FamiliaContempladaDto
    {
        public Guid Id { get; set; }
        public int QuantidadeDeCriteriosAtendidos { get; set; }
        public int PontuacaoTotal { get; set; }
        public DateTime DataDaSelecao { get; set; }
    }
}