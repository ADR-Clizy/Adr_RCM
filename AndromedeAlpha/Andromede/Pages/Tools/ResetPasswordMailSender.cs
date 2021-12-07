using DatabaseConnection;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Andromede.Pages.Tools
{
    class NewPasswordTemplateData
    {
        [JsonProperty("reset_password_link")]
        public string ResetPasswordLink { get; set; }

        [JsonProperty("restaurant_name")]
        public string RestaurantName { get; set; }

        [JsonProperty("end_guid_time")]
        public string EndGuidTime { get; set; }
    }

    public static class ResetPasswordMailSender
    {
        public static async Task SendMail(RestorerClaim iRestorerClaim, Restorer iRestorer)
        {
            string anApiKey = Environment.GetEnvironmentVariable("ANDROMEDE_MAILING_SYSTEM");
            SendGridClient aClient = new SendGridClient(anApiKey);
            EmailAddress aFromMail = new EmailAddress("adr.clizy@outlook.fr", "Andromede Services");
            string aSubject = "Reinitialisation du mot de passe";
            var aToMail = new EmailAddress(iRestorer.EmailAddress, iRestorer.RestaurantName);
            string aDomainName = "https://localhost:5001";
            string aNewPasswordLink = aDomainName + $"/RestorerManagment/NewPassword/{iRestorerClaim.ClaimGUID}";
            var aMail = new SendGridMessage();
            aMail.SetFrom(aFromMail);
            aMail.AddTo(aToMail);
            aMail.SetSubject(aSubject);
            aMail.SetTemplateId("d-939cd973e5cd4e9d873ec2a31e679be1");

            var aTemplateData = new NewPasswordTemplateData
            {
                ResetPasswordLink = aNewPasswordLink,
                RestaurantName = iRestorer.RestaurantName,
                EndGuidTime = iRestorerClaim.EndOfGUID.Hour + "H" + iRestorerClaim.EndOfGUID.Minute
            };
            aMail.SetTemplateData(aTemplateData);
            await aClient.SendEmailAsync(aMail);
        }


        

    }
}
