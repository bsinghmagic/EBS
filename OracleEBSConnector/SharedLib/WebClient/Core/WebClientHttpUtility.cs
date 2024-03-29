﻿using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;


namespace WebClientUtility.Core
{
    /// <summary>
    /// HttpUtility implementation using WebClient and Auth token
    /// </summary>
    public class WebClientHttpUtility: IHttpUtility
    {
        private static WebClient HttpClientFactory() {
            WebClient client = new WebClient();

            //client.Headers.Add("Authorization", ApplicationConfig.AuthToken);
            return client;
        }

        private static Uri ToAbsoluteUrl(string uri)
        {
            return Uri.IsWellFormedUriString(uri, UriKind.Absolute) ? 
                new Uri(uri) : 
                new Uri(ApplicationConfig.Sage50ConnectorBaseUri, uri);
        }

        /// <summary>
        /// Uploads the specified name/value collection to the resource identified by the specified URI via POST Request
        /// content-type: application/x-www-формы-urlencoded
        /// </summary>
        /// <param name="uri">resource URI</param>
        /// <param name="parameters">name/value collection</param>
        /// <returns></returns>
        public string Post(string uri, NameValueCollection parameters)
        {
            using (var client = HttpClientFactory())
            {
                var response = client.UploadValues(ToAbsoluteUrl(uri), parameters ?? new NameValueCollection());
                return Encoding.UTF8.GetString(response);
            }
        }

        /// <summary>
        /// Downloads the requested resource as a String via GET request with query parameters specified in name/value collection
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="parameters">name/value collection</param>
        /// <returns></returns>
        public string Get(string uri, NameValueCollection parameters)
        {
            using (var client = HttpClientFactory())
            {
                foreach (string parameter in parameters.Keys)
                {
                    client.QueryString.Add(parameter, parameters[parameter]);
                }
                return client.DownloadString(ToAbsoluteUrl(uri));
            }
        }

        public string Get(string uri)
        {
            return Get(uri, new NameValueCollection());
        }

        public string Patch(string uri, string body, string contentType)
        {
            return Request(uri, body, contentType, "PATCH");
        }

        public string Post(string uri, string body, string contentType)
        {
            return Request(uri, body, contentType, "POST");
        }

        private string Request(string uri, string body, string contentType, string method)
        {
            using (var client = HttpClientFactory())
            {
                client.Headers["Content-Type"] = contentType;
                client.Headers["Accept"] = contentType;
                ServicePointManager.Expect100Continue = true;
            
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var result = client.UploadData(ToAbsoluteUrl(uri), method, Encoding.UTF8.GetBytes(body));

                return Encoding.UTF8.GetString(result);
            }
        }
    }
}