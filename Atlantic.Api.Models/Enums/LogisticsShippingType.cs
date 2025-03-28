using System.ComponentModel;

namespace Atlantic.Api.Models.Enums
{
    public enum LogisticsShippingType
    {
        [Description("MOTOCICLISTA")]
        MOTOCICLISTA = 1,

        [Description("TAXI")]
        TAXI = 2,

        [Description("SEDEX")]
        SEDEX = 3,

        [Description("E-SEDEX")]
        E_SEDEX = 4,

        [Description("PAC")]
        PAC = 5,

        [Description("SEDEX-10")]
        SEDEX_10 = 7,

        [Description("JADLOG")]
        JADLOG = 8,

        [Description("MATRIZ BLACK")]
        MATRIZ_BLACK = 9,

        [Description("EMLOG-12")]
        EMLOG_12 = 10,

        [Description("ICONEX-ECONOMICA")]
        ICONEX_ECONOMICA = 12,

        [Description("SEDEX-12")]
        SEDEX_12 = 13,

        [Description("TOTAL")]
        TOTAL_EXPRESS = 14,

        [Description("RETIRAR EM LOJA")]
        RETIRAR_EM_LOJA = 15,

        [Description("TNT")]
        TNT = 18,

        [Description("LOGGI")]
        LOGGI = 19,

        [Description("COOPERMOTO")]
        COOPERMOTO = 20,

        [Description("GOLLOG")]
        GOLLOG = 21,

        [Description("JC TRANSPORTE")]
        JC_TRANSPORTE = 22,

        [Description("SEQUOIA")]
        SEQUOIA = 24,

        [Description("LOGX")]
        LOGX = 25,

        [Description("SHOPEE")]
        SHOPEE = 26
    }
}
