using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

public enum PerfilEnum
{
    [Description("Possui acesso completo ao sistema, podendo gerenciar cooperados, usuários, bases, funções, documentos, férias, financeiro, relatórios e configurações.")]
    Administrador = 1,

    [Description("Responsável pela gestão dos cooperados vinculados às bases sob sua responsabilidade, podendo consultar informações, acompanhar documentos, plantões e solicitações conforme suas permissões.")]
    Coordenador = 2,

    [Description("Possui acesso às próprias informações cadastrais, documentos, plantões, saldo de férias, solicitações e treinamentos disponibilizados pelo sistema.")]
    Cooperado = 3,

    [Description("Perfil com permissões configuráveis individualmente, permitindo liberar ou restringir funcionalidades e módulos conforme a necessidade administrativa.")]
    Personalizado = 4
}
