using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DatabaseConnection
{
    public class Card
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        [RegularExpression(@"^[a-zA-Zéèçëïêîèìœ\s]+$",
         ErrorMessage = "Chiffres / Caractères spéciaux interdits")]
        [MaxLength(40, ErrorMessage = "Champ trop long")]
        public string CardName { get; set; }

        public int RestorerId { get; set; }
        public Restorer Restorer { get; set; }
    }
}
