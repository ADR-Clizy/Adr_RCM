using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.RestorerModels
{
    public class RestorerNewPassword
    {
        [Required(ErrorMessage = "Champ requis")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Champ trop court (entre 6 et 20 caractères)")]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$&*])$",
        // ErrorMessage = "Doit contenir 1 chiffre et 1 caractère spécial")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Champ trop court (entre 6 et 20 caractères)")]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$&*])$",
        // ErrorMessage = "Doit contenir 1 chiffre et 1 caractère spécial")]
        public string PasswordConfirmed { get; set; }
    }
}
