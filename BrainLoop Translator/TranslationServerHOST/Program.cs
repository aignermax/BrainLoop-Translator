using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using TranslationWCFService;

namespace TranslationServerHOST
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8733/TranslationWCFService/");
            ServiceHost myHost = new ServiceHost(typeof(TranslatorService), baseAddress);
            // Note: This server has to be run as Administrator in order to work. (or Visual Studio has to be run as Admin)

            try
            {
                myHost.AddServiceEndpoint(typeof(ITranslatorService), new WSHttpBinding(), "TranslatorService");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                myHost.Description.Behaviors.Add(smb);

                myHost.Open();
                Console.WriteLine("Translator Service is ready \n");
                Console.ReadLine();
                myHost.Close();
            } catch (CommunicationException ex)
            {
                Console.WriteLine("An Exception occured: " + ex.Message);
                myHost.Abort();
            }
        }
    }
}
