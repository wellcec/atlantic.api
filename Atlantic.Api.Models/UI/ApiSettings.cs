using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Atlantic.Api.Models.UI
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// Class to use data from appsettings.json "Settings" field
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Current API Version
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// When running locally, our APIs don't need to define localhost as the host of the API,
        /// however, when we do define the host, the API will start throwing exceptions on the console.
        /// When we remove it completely, the exceptions will be thrown on the Kubernetes environment.
        /// In order to eliminate this issue, define this property with an empty value on appsettings.Development.json
        /// and with the standard host on appsettings.json, as Kubernetes will read the value defined on HealthChecksUiUrl
        /// based on this file.
        /// </summary>
        public string HealthChecksUiUrl { get; set; }

        /// <summary>
        /// Bot's BLiP Authorization Key Header
        /// </summary>
        public string Authorization { get; set; }

        /// <summary>
        /// Disable notification in route Order/notification/status
        /// </summary>
        public bool DisableNotification { get; set; }

        /// <summary>
        /// SwaggerCredentials
        /// </summary>
        public SwaggerCredentials SwaggerCredentials { get; set; }
    }
}
