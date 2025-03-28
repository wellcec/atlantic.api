using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace Atlantic.Api.Models
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const string BLIP_USER_HEADER = "X-Blip-User";
        public const string BLIP_BOT_HEADER = "X-Blip-Bot";
        public const string BLIP_BOT_KEY = "X-Bot-Key";
        public const string XML_EXTENSION = ".xml";
        public const string PROJECT_NAME = "Atlantic.Api";
        public const string KEY_ENV_NOTIFICATION = "prd";
        public const string BASE_DOMAIN = "wa.gw.msging.net";

        public const string WARN_ME = "bot_araujo:WarnMe_";
        public const string KEY_BLACK_LIST = "bot_araujo:blacklist";
        public const string KEY_TEST_PHONES_LIST = "bot_araujo:testphones";
        public const string KEY_CATEGORIES_CONTROL = "bot_araujo:categories_control";
        public const string KEY_PRODUCTS_CONTROL = "bot_araujo:products_control";
        public const string KEY_SETTINGS_CONTROL = "bot_araujo:settings_control";
        public const int REDIS_DAYS = 30;
        public const int REDIS_TRACED_DAYS = 4;
        public const string PAYMENT_STATUS_AUTHORIZED = "AUTORIZADO";
        public const string PAYMENT_STATUS_APPROVED = "APPROVED_PAYMENT";
        public const string PAYMENT_STATUS_PAGO = "PAGO";
        public const string PAYMENT_STATUS_PAID = "PAID";
        public const string PAYMENT_STATUS_UNAUTHORIZED = "NEGADO";
        public const string PAYMENT_STATUS_CANCELLED = "CANCELADO";
        public const string PAYMENT_STATUS_PIX_EXPIRED = "cancelled";

        public const int PRODUCTS_DEFAULT_PAGE = 1;
        public const int PRODUCTS_DEFAULT_TAKE = 20;
        public const int TIME_TO_DELAY_STRATEGIES = 2000;

        public const int ORDER_PICKUP = 15;
        public const int ORDER_SHIPPING = 1;

        public const int BRAZIL_DDI = 55;
        public const int PHONE_SIZE = 11;
        public const int PHONE_SIZE_DDI = 13;
        public const int MASK_SIZE = 4;
        public const char SEPARATOR = ':';
        public const char ONE_SPACE = ' ';
        public const char AT = '@';
        public const char COMMA = ',';
        public const char DOT = '.';

        public const string DASH_SEPARATOR = "-";
        public const string TO_ACTIVE_CAMPAIGN = "postmaster@activecampaign.msging.net";
        public const string ASTERISK = "*";
        public const string POSITIVE = "+";
        public const string LOCAL_CURRENCY = "R$";

        //Order
        public const int DECIMAL_PLACES = 2;
        public const int STORE_PICK_UP_NUMBER_MESSAGE_PARAMETERS = 7;
        public const int PRODUCTS_COUNT_ONE = 1;
        public const int PRODUCTS_COUNT_TWO = 2;
        public const int PRODUCTS_COUNT_THREE = 3;
        public const string ORDER_STATUS_ATTENDANCE = "Atendido";
        public const string ORDER_STATUS_WAITING_EXPEDITION = "Aguardando Expedição";
        public const string ORDER_STATUS_CANCELLED = "Cancelado";
        public const string ORDER_STATUS_RETURNED = "Devolvido Total";
        public const string ORDER_STATUS_DISPATCHED = "Expedido";
        public const string ORDER_STATUS_DELIVERED = "Entregue";
        public const string PICK_UP_STORE_DEFAULT_VALUE = "RETIRAR_LOJA";
        public const string CHANNEL_SALE_MANIPULATED = "3";

        //Notification
        public const string ORDER_ANSWERED = "03 - 'Atendido'";
        public const string ORDER_DISPATCHED_SITE = "10 - 'Expedido'";
        public const string WAITING_SHIPPING_PICK_UP = "19 - 'Aguardando Expedição' - TRANSPORTADORA";
        public const string WAITING_STORE_PICK_UP = "19 - 'Aguardando expedição' - RETIRADA NA LOJA";
        public const string IN_NEGOTIATION = "07 - 'Em Negociação'";
        public const string WAITING_LOCKER_PICK_UP = "19 - 'Aguardando expedição' - RETIRADA NO LOCKER";
        public const string PICK_UP_REMINDER = "xx - 'Lembrete para retirada'";
        public const string ORDER_PICKED_UP_SITE = "11 - 'Entregue' - RETIRADA";
        public const string ORDER_CANCELLED_SITE = "12 E 13- 'Cancelado/devolução total'";
        public const string WAITING_MOTORCYCLE_PICK_UP = "19 - 'Aguardando Expedição' - MOTO";
        public const string ORDER_READY_FOR_PICK_UP = "11 - 'Entregue' - TRANSPORTADORA";
        public const string ORDER_DELIVERED_MOTORCYCLE_SITE = "11 - 'Entregue' - MOTO";
        public const string NOT_DELIVERED = "09 - 'Não entregue'";
        public const string PAYMENT_CONFIRMATION = "27 - 'Ag. Conf. Pagamento Drogatel - Cartao'";
        public const string HEALTH_SERVICE_CANCELLED_DEVOLUTION = "12 E 13- 'Cancelado/devolução total Servico Saude'";
        public const string WAITING_TREATMENT = "05 - 'Ag. Atend Servico Saude'";
        public const string WAITING_PICK_UP_MANIPULATED = "19 - 'Aguardando expedição' - MANIPULADO";
        public const string PRE_ORDER_PRODUCT = "20 - 'Aguardando mercadoria'";
        public const string SUPER_VENDOR_LINK = "27 - 'Ag. Conf. Pagamento - Supervendedor'";
        public const string WAITING_PAYMENT_PIX = "27 - 'Ag. Conf. Pagamento Drogatel - PIX'";
        public const string DELAY = "XX - 'Atraso'";
        public const string REORDER = "XX - 'Recompra - OPTIN'";
        public const string REORDER_INACTIVITY = "XX - 'Recompra - OPTIN Inatividade'";
        public const string MONITORING_STORE = "Monitoramento - PDV Loja";

        //Logistics
        public static readonly string[] DEFAULT_LOGISTICS_SALES_CHANNELS = new[] { "W", "B" };
        public const string PICK_UP_DELIVERY_TYPE = "15";
        public const string FOUR_DOT_ZERO_DELIVERY_TYPE = "1";
        public const string FOUR_DOT_ZERO_SHIPPING_TYPE = "PRECO_FIXO";
        public const string PICK_UP_SHIPPING_TYPE = "RETIRADA_EM_LOJA";
        public const string PICK_UP_SHIPPING_RETIRADA = "RETIRADA_BALCAO";
        public const string PICK_UP_SHIPPING_RETIRADA_LOCKER = "RETIRADA_ARMARIO";
        public const int DEFAULT_MERCADOPAGO_EXPIRATION_IN_MINUTES = 30;
        public const int DEFAULT_BRADESCO_EXPIRATION_IN_DAYS = 1;
        public const int DEFAULT_BRADESCO_EXTENDED_EXPIRATION_IN_HOURS = 72;
        public const int AVAILABLE_QUANTITY = 0;

        //Securiti AI
        public const string DEFAULT_CONSENT_SOURCE = "Contato";
        public const string SECURITI_API_SUCCESS_MESSAGE = "Consent scheduled for Upload Successfully!";

        //Localization
        public const string GOOGLE_API_RESPONSE_OK_STATUS = "OK";
        public const string GOOGLE_STREET_NAME_TYPE = "route";
        public const string GOOGLE_STREET_NUMBER_TYPE = "street_number";
        public const string GOOGLE_STREET_NEIGHBORHOOD_TYPE = "sublocality_level_1";
        public const string GOOGLE_STREET_CITY_TYPE = "administrative_area_level_2";
        public const string GOOGLE_STREET_STATE_TYPE = "administrative_area_level_1";
        public const string GOOGLE_STREET_ZIPCODE_TYPE = "postal_code";


        // Time
        public const string TIME_ZONE_INFO = "America/Sao_Paulo";
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const string DATE_TIME_FORMAT = "dd/MM/yyyy HH:mm";
        public const string TIME_FORMAT = "t";
        public const string FORMAT_DATE = "yyyy-MM-ddTHH:mm:ss.fffZ";

        public const string FORMAT_DATE_TIMEZONE = "yyyy-MM-ddTHH:mm:ss.fffZ";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM = "yyyy-MM-ddTHH:mm:ss.fffffff";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM_1 = "yyyy-MM-ddTHH:mm:ss.fffffffzzz";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM_2 = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM_3 = "yyyy-MM-ddTHH:mm:ssZ";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM_4 = "yyyy-MM-dd HH:mm:ss";

        public const string BLIP_RECIPIENT_POSTMASTER = "postmaster@msging.net";
        public const string BLIP_RECIPIENT_MEDIA_POSTMASTER = "postmaster@media.msging.net";

        //Payment
        public const string KEY_CREDIT_CARD = "CREDIT_CARD";
        public const string KEY_MERCADOPAGO = "MERCADOPAGO";
        public const string KEY_CIELO = "Cielo30";
        public const string KEY_FLAG_MASTER_RECEIVED = "MASTER";
        public const string KEY_FLAG_MASTER_SENDED = "MAST";
        public const string KEY_BRADESCO = "BRADESCO";
        public const string CARD_PAYMENT = "Card";
        public const string PIX_PAYMENT = "Pix";
        public const string PIX_PAYMENT_BRADESCO = "PixBradesco";
        public const string PREFIX_NUMBER_ID_BWP = "BWP";
        public const string PREFIX_NUMBER_ID_WPP = "WPP";
        public const string PREFIX_NUMBER_ID_SF = "SF";
        public const long NUMBER_ID_BASE = 3000000000000000;

        //Historic
        public const string CAR_PAYMENT_HISTORIC = "CARTAO_CREDITO";

        //Types products
        public const string CONTROLLED = "controlado";
        public const string MANIPULATED = "manipulado";
        public const string VACCINE = "vacina";

        //Images links templates
        public const string ORDER_PICKED_UP_SITE_HEADER = "https://digitalbot.com.br/Araujo/dli_tracking_pedidos.png";
        public const string ORDER_PICKED_UP_WPP_BLACKFRIDAY = "https://blipmediastore.blob.core.windows.net/public-medias/Media_1ade97cf-6376-4f92-9088-117bec9b7053";

        //Pix Bradesco Status
        public const string PIX_BRADESCO_PAID = "PAGO";
        public const string PIX_BRADESCO_EXPIRED = "EXPIRADO";
        public const string PIX_BRADESCO_OPENED = "EM_ABERTO";

        //Tracking
        public const string ORDER_DROGATEL_TRACKING = "Pedido Drogatel";
        public const string STATUS_PAYMENT_TRACKING = "Status pagamento";
        public const string CATEGORY_GOOGLE_TRACKER = "clicktracker_google";
        public const string ACTION_GOOGLE_TRACKER = "success-order-manip";

        //Blip
        public const string REFRESH_MEDIA_URI = "/refresh-media-uri";
    }
}
