using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class RestorerClaim
    {
        [Key]
        public int RestorerClaimId { get; set; }

        public string ClaimGUID { get; set; }

        public DateTime EndOfGUID { get; set; }

        public int RestorerId { get; set; }
        public Restorer Restorer { get; set; }
    }
}
