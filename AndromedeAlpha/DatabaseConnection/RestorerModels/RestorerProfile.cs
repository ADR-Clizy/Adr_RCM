using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.RestorerModels
{
    public class RestorerProfile
    {
        [RegularExpression(@"^\d+$",
         ErrorMessage = "Seuls les chiffres sont autorisés")]
        public string RestaurantSiretNumber { get; set; }


        [Required(ErrorMessage = "Champ requis")]
        [RegularExpression(@"^[a-zA-Z0-9éèçëïêîèìœ\s]+$",
         ErrorMessage = "Caractères spéciaux interdits")]
        [MaxLength(50, ErrorMessage = "Champ trop long")]
        public string RestaurantName { get; set; }


        [RegularExpression(@"^[a-zA-Zéèçëïêîèìœ\s]+$",
         ErrorMessage = "Chiffres / Caractères spéciaux interdits")]
        [MaxLength(40, ErrorMessage = "Champ trop long")]
        public string FirstName { get; set; }


        [RegularExpression(@"^[a-zA-Zéèçëïêîèìœ\s]+$",
         ErrorMessage = "Chiffres / Caractères spéciaux interdits")]
        [MaxLength(40, ErrorMessage = "Champ trop long")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Champ requis")]
        [EmailAddress(ErrorMessage = "Format incorrect")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Champ requis")]
        [Phone(ErrorMessage = "Format incorrect")]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string FacebookLink { get; set; }

        public string TwitterLink { get; set; }

        public string InstagramLink { get; set; }

        public string LinkedInLink { get; set; }
    }
}
