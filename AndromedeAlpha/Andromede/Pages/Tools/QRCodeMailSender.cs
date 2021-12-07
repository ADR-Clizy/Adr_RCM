using DatabaseConnection;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using SendGrid;
using QuickResponseCodeManager;

namespace Andromede.Pages.Tools
{
    class CardsQRCodeTemplateData
    {
        [JsonProperty("restaurant_name")]
        public string RestaurantName { get; set; }
    }

    public class QRCodeMailSender
    {
        public static async Task SendMail(Restorer iRestorer)
        {
            string anApiKey = Environment.GetEnvironmentVariable("ANDROMEDE_MAILING_SYSTEM");
            SendGridClient aClient = new SendGridClient(anApiKey);
            EmailAddress aFromMail = new EmailAddress("adr.clizy@outlook.fr", "Andromede Services");
            var aToMail = new EmailAddress(iRestorer.EmailAddress, iRestorer.RestaurantName);
            var aMail = new SendGridMessage();
            var aDomainName = "https://localhost:5001";
            var aQRCodeLink = aDomainName + $"/CardManagment/Customer/Cards/{iRestorer.RestorerId}";
            AddPDFAttachment(aMail, aQRCodeLink); 
            AddPNGAttachment(aMail, aQRCodeLink);
            aMail.SetFrom(aFromMail);
            aMail.AddTo(aToMail);
            aMail.SetTemplateId("d-b7c9989f0c144e2792980145e3911082");

            var aTemplateData = new CardsQRCodeTemplateData
            {
                RestaurantName = iRestorer.RestaurantName
            };
            aMail.SetTemplateData(aTemplateData);
            
            await aClient.SendEmailAsync(aMail);
        }

        public static void AddPDFAttachment(SendGridMessage iMail, string iLink)
        {
            var anAttachment = new Attachment
            {
                Filename = "Plaquette_QRCode.pdf",
                Content = Convert.ToBase64String(QRCodePDFGenerator.GenerateNormalQRCodePdf(iLink)),
                Type = "application/pdf",
                ContentId = "cards_qr_code_pdf"
            };

            iMail.AddAttachment(anAttachment);
        }
        
        public static void AddPNGAttachment(SendGridMessage iMail, string iLink)
        {
            var anAttachment = new Attachment
            {
                Filename = "Image_QRCode.png",
                Content = Convert.ToBase64String(QRCodeManager.GenerateQRCode(iLink, 10)),
                Type = "image/png",
                ContentId = "cards_qr_code_png"
            };

            iMail.AddAttachment(anAttachment);
        }
    }
}
