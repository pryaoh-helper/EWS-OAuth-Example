using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Exchange.WebServices.Data;

using EWSOAuthDemo.Helpers;
namespace EWSOAuthDemo
{

    public enum AuthType
    {
        Delegate,
        Application
    }

    class Program
    {
        static void Main(string[] args)
        {
            if(args == null)
            {
                Console.WriteLine("Should args : (-d) Delegate (-a) Application");
                return;
            }

            AuthType type;

            if (args[0].Equals("-d"))
            {
                type = AuthType.Delegate;
            } else if(args[0].Equals("-a"))
            {
                type = AuthType.Application;
            }
            else
            {
                Console.WriteLine("Should args : (-d) Delegate (-a) Application");
                return;
            }


            ProcAsync(type).Wait();

            Console.WriteLine("Hit any key to exit...");
            Console.ReadKey();
        }

        static async System.Threading.Tasks.Task ProcAsync(AuthType type )
        {
            var ewsClient = new ExchangeService();

            ExchangeCredentials credentials = null;

            if(type == AuthType.Application)
            {
                credentials = await EWSHelper.DoOAuthApplication();
            }
            else
            {
                credentials = await EWSHelper.DoOAuthDelegate();
            }
            
            try
            {
                ewsClient.Url = new Uri(EWSConstants.OutlookUrl);
                ewsClient.Credentials = credentials;


                if (type == AuthType.Application)
                {
                    ewsClient.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress,
                        "yaoh@factorylaon.com");

                    //Include x-anchormailbox header
                    ewsClient.HttpHeaders.Add("X-AnchorMailbox", "yaoh@factorylaon.com");
                }
                

                // Make an EWS call
                var folders = ewsClient.FindFolders(WellKnownFolderName.MsgFolderRoot, new FolderView(10));
                foreach (var folder in folders)
                {
                    Console.WriteLine($"Folder: {folder.DisplayName}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }
    }
}
