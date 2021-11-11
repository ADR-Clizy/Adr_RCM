
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class Restorer
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Champ requis")]
        [RegularExpression(@"^\d+$",
         ErrorMessage = "Seuls les chiffres sont autorisés")]
        [MaxLength(14, ErrorMessage = "Champ trop long")]
        [MinLength(14, ErrorMessage = "Champ trop court")]
        public string RestaurantSiretNumber { get; set; }


        [Required(ErrorMessage = "Champ requis")]
        [RegularExpression(@"^[a-zA-Z0-9éèçëïêîèìœ\s]+$",
         ErrorMessage = "Caractères spéciaux interdits")]
        [MaxLength(50, ErrorMessage = "Champ trop long")]
        public string RestaurantName { get; set; }


        public string RestaurantState { get; set; }


        [Required(ErrorMessage = "Champ requis")]
        [RegularExpression(@"^[a-zA-Zéèçëïêîèìœ\s]+$",
         ErrorMessage = "Chiffres / Caractères spéciaux interdits")]
        [MaxLength(40, ErrorMessage = "Champ trop long")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Champ requis")]
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


        [Required(ErrorMessage = "Champ requis")] 
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Subscribed { get; set; } = false;

        public DateTime DateOfSubscription { get; set; }
    }
}
