using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public interface IRestorerClaimRepository
    {
        RestorerClaim GetRestorerClaimWithId(int iRestorerClaimId);
        RestorerClaim GetRestorerClaimWithGUID(string iClaimGUID);
        DateTime? GetRestorerClaimEndOfGUID(int iRestorerClaimId);
        RestorerClaim NewRestorerClaim(RestorerClaim ioRestorerClaim);
        RestorerClaim DeleteRestorerClaim(int iRestorerClaimId);
    }
}
