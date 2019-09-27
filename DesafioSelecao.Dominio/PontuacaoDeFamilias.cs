using System;
using DesafioSelecao.Dominio.Comum;
using DesafioSelecao.Dominio.Criterios;

namespace DesafioSelecao.Dominio
{
    public class PontuacaoDeFamilias
    {
        public void Pontuar(Criterio criterio, Familia familia)
        {
            if(familia.Status != Status.CadastroValido)
                throw new ExcecaoDeDominio("Não é possível pontuar família que não esteja com cadastro válido");

            if (criterio.EhAtendidoPela(familia) <= 0) return;

            familia.Pontuacao += criterio.EhAtendidoPela(familia);
            familia.QuantidadeDeCriteriosAtendidos++;
        }
    }
}