using System;
using System.Diagnostics.CodeAnalysis;

using Atlantic.Api.Models.Enums;

namespace Atlantic.Api.Models.WarnMe
{
    [ExcludeFromCodeCoverage]
    public class WarnMeRecord
    {
        public string WarnMeKey { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Date { get; set; }

        public LogisticsType Type { get; set; }

        public string StoreName { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string StreetName { get; set; }

        public string RouterIdentifier { get; set; }

        public string PaymentMetodh { get; set; }

        public string ShippingAddress { get; set; }

        public double ShippingPrice { get; set; }
    }
}
