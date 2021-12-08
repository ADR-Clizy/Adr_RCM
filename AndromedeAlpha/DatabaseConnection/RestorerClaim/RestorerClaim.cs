/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using System;
using System.ComponentModel.DataAnnotations;

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
