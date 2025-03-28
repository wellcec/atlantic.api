using System.ComponentModel;

namespace Atlantic.Api.Models.Enums
{
    public enum DrogatelOrderStatus
    {
        [Description(Constants.ORDER_STATUS_ATTENDANCE)]
        Atendido = 03,

        [Description(Constants.ORDER_STATUS_DISPATCHED)]
        Expedido = 10,

        [Description(Constants.ORDER_STATUS_DELIVERED)]
        Entregue = 11,

        [Description(Constants.ORDER_STATUS_CANCELLED)]
        Cancelado = 12,

        [Description(Constants.ORDER_STATUS_RETURNED)]
        DevolucaoTotal = 13,

        [Description(Constants.ORDER_STATUS_WAITING_EXPEDITION)]
        AguardandoExpedicao = 19,
    }
}
