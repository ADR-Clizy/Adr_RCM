/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using System.ComponentModel.DataAnnotations;

namespace DatabaseConnection
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        [MaxLength(40, ErrorMessage = "40 caractères maximum")]
        public string CardName { get; set; }

        public int RestorerId { get; set; }
        public Restorer Restorer { get; set; }
    }
}
