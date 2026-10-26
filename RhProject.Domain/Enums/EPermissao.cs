using System.ComponentModel;

namespace RhProject.Domain.Enums
{
    public enum PermissaoEnum
    {
        [Description("Visualizar cooperados")]
        CooperadoVisualizar = 1,

        [Description("Cadastrar cooperados")]
        CooperadoCriar = 2,

        [Description("Editar cooperados")]
        CooperadoEditar = 3,

        [Description("Excluir cooperados")]
        CooperadoExcluir = 4,

        [Description("Visualizar financeiro")]
        FinanceiroVisualizar = 5,

        [Description("Gerenciar financeiro")]
        FinanceiroGerenciar = 6,

        [Description("Visualizar férias")]
        FeriasVisualizar = 7,

        [Description("Aprovar férias")]
        FeriasAprovar = 8,

        [Description("Visualizar relatórios")]
        RelatoriosVisualizar = 9,

        [Description("Visualizar bases")]
        BaseVisualizar = 10,

        [Description("Cadastrar bases")]
        BaseCriar = 11,

        [Description("Editar bases")]
        BaseEditar = 12,

        [Description("Excluir bases")]
        BaseExcluir = 13
    }
}