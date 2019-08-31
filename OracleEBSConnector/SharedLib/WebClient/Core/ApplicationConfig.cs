using System;
using System.Collections.Generic;
using System.Configuration;


namespace WebClientUtility.Core
{
    /// Serivce Configuration Wrapper
    static partial class ApplicationConfig
    {
        /// <summary>
        /// A valid application ID is needed in order to connect to regular Sage 50 companies
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static string Sage50ApplicationID => ConfigurationManager.AppSettings["Sage50ApplicationID"];

        /// <summary>
        /// Sage50Connector REST Api Base Url
        /// </summary>
        public static Uri Sage50ConnectorBaseUri => new Uri(ConfigurationManager.AppSettings["Sage50ConnectorBaseUrl"]);

  
        /// <summary>
        /// Sage50 SDK COM UserName
        /// </summary>
        public static string Sage50SDKCOMUserName => ConfigurationManager.AppSettings["Sage50SDKCOMUserName"];
        /// <summary>
        ///  Sage50 SDK COM Password
        /// </summary>
        public static string Sage50SDKCOMPassword => ConfigurationManager.AppSettings["Sage50SDKCOMPassword"];

 

        /// <summary>
        /// Customers LastSavedAt value filter
        /// </summary>
        public static DateTime CustomersLastSavedAt
        {
            get => GetAppSettingsValue<DateTime>(CustomersLastSavedAtKey);
            set => SetAppSettingsProperty(CustomersLastSavedAtKey, TypeUtil.DateToUTC(value));
        }

        private const string CustomersLastSavedAtKey = "Customers_LastSavedAt";
    }
}
