using System.ComponentModel;

namespace DesafioSelecao.Dominio
{
    public enum Status
    {
        [Description("Cadastro válido")]
        CadastroValido = 0,
        [Description("Já possuí uma casa")]
        JaPossuiUmaCasa = 1,
        [Description("Selecionada em outro processo")]
        SelecionadaEmOutroProcesso = 2,
        [Description("Cadastro incompleto")]
        CadastroIncompleto = 3
    }
}