using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using Microsoft.Identity.Client;
using Microsoft.Exchange.WebServices.Data;

namespace EWSOAuthDemo.Helpers
{
    public static class EWSHelper
    {

        /// <summary>
        ///  Delegate Permission
        /// </summary>
        /// <returns></returns>
        public static async Task<ExchangeCredentials> DoOAuthDelegate()
        {
            var options = new PublicClientApplicationOptions()
            {
                ClientId = ConfigurationManager.AppSettings["clientId"],
                TenantId = ConfigurationManager.AppSettings["tenantId"]
            };

            var app = PublicClientApplicationBuilder
               .CreateWithApplicationOptions(options).Build();

            var ewsScopes = new string[] { EWSConstants.DeleageScope };

            AuthenticationResult result = null;

            try
            {
                result = await app.AcquireTokenInteractive(ewsScopes).ExecuteAsync();
                var oAuthCredential = new OAuthCredentials(result.AccessToken);

                return oAuthCredential;
            }
            catch (MsalException ex)
            {
                Console.WriteLine($"Error acquiring access token: {ex.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.ToString()}");
            }

            return null;
        }

        /// <summary>
        ///  Application Permission
        /// </summary>
        /// <returns></returns>
        public static async Task<ExchangeCredentials> DoOAuthApplication()
        {
            var ewsScopes = new string[] { EWSConstants.ApplicationScope };

         
            var app = ConfidentialClientApplicationBuilder.Create(ConfigurationManager.AppSettings["clientId"])
                .WithAuthority(AzureCloudInstance.AzurePublic, ConfigurationManager.AppSettings["tenantId"])
                .WithClientSecret(ConfigurationManager.AppSettings["clientSecret"])
                .Build();

            AuthenticationResult result = null;

            try
            {
                result = await app.AcquireTokenForClient(ewsScopes).ExecuteAsync();
                var oAuthCredential = new OAuthCredentials(result.AccessToken);

                return oAuthCredential;
            }
            catch (MsalException ex)
            {
                Console.WriteLine($"Error acquiring access token: {ex.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.ToString()}");
            }

            return null;
        }


    }
}
