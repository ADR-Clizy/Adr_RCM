/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class SQLRestorerClaimRepository : IRestorerClaimRepository
    {
        private readonly AndromedeDbContext _context;

        public SQLRestorerClaimRepository(AndromedeDbContext context)
        {
            _context = context;
        }

        public RestorerClaim DeleteRestorerClaim(int iRestorerClaimId)
        {
            RestorerClaim aRestorerClaim = _context.RestorerClaims.Find(iRestorerClaimId);
            if(aRestorerClaim != null)
            {
                _context.RestorerClaims.Remove(aRestorerClaim);
                _context.SaveChanges();
            }
            return aRestorerClaim;
        }

        public DateTime? GetRestorerClaimEndOfGUID(int iRestorerClaimId)
        {
            RestorerClaim aRestorerClaim = _context.RestorerClaims.Find(iRestorerClaimId);
            if(aRestorerClaim != null)
            {
                return aRestorerClaim.EndOfGUID;
            }
            return null;
        }

        public RestorerClaim GetRestorerClaimWithGUID(string iClaimGUID)
        {
            return _context.RestorerClaims.FirstOrDefault(aRestorerClaim => aRestorerClaim.ClaimGUID == iClaimGUID);
        }

        public RestorerClaim GetRestorerClaimWithId(int iRestorerClaimId)
        {
            return _context.RestorerClaims.Find(iRestorerClaimId);
        }

        public RestorerClaim NewRestorerClaim(RestorerClaim ioRestorerClaim)
        {
            _context.RestorerClaims.Add(ioRestorerClaim);
            _context.SaveChanges();
            return ioRestorerClaim;
        }
    }
}
