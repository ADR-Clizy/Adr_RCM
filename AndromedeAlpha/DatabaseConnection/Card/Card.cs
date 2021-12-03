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
        [Key]
        public int CardId { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        [MaxLength(40, ErrorMessage = "Champ trop long")]
        public string CardName { get; set; }

        public int RestorerId { get; set; }
        public Restorer Restorer { get; set; }
    }
}
