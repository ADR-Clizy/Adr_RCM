using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.RestorerModels
{
    public class RestorerMailOnly
    {
        [Required(ErrorMessage = "Champ requis")]
        [EmailAddress(ErrorMessage = "Format incorrect")]
        public string EmailAddress { get; set; }
    }
}
