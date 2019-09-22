using System;
using System.Linq;

namespace DesafioSelecao.Dominio.Criterios
{
    public class CriterioDePretendenteComIdadeIgualOuMaiorA45Anos : Criterio
    {
        private const int Pontos = 3;

        public override int EhAtendidoPela(Familia familia)
        {
            var pretendente = familia.Pessoas.First(p => p.Tipo == TipoDePessoa.Pretendete);
            //TODO Extrair o calculo da idade como uma propridade de Pessoa
            var idadeDoPretendente = CalcularIdade(pretendente.DataDeNascimento, DateTime.Now);
            return idadeDoPretendente >= 45 ? Pontos : 0;
        }

        private static int CalcularIdade(DateTime dataDeNascimento, DateTime dataDeHoje)
        {
            return (dataDeHoje.Year - dataDeNascimento.Year - 1) +
                   (((dataDeHoje.Month > dataDeNascimento.Month) ||
                     ((dataDeHoje.Month == dataDeNascimento.Month) && (dataDeHoje.Day >= dataDeNascimento.Day))) ? 1 : 0);
        }
    }
}