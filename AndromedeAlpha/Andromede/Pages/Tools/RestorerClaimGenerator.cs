/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using DatabaseConnection;
using System;
using System.Linq;

namespace Andromede.Pages.Tools
{
    public static class RestorerClaimGenerator
    {
        public static RestorerClaim GenerateRestorerClaim(int iRestorerId)
        {
            RestorerClaim aRestorerClaim = new RestorerClaim();
            aRestorerClaim.ClaimGUID = GenerateGUID();
            aRestorerClaim.RestorerId = iRestorerId;
            aRestorerClaim.EndOfGUID = DateTime.Now.AddHours(4);
            return aRestorerClaim;
        }

        public static string GenerateGUID()
        {
            Random aRandom = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[aRandom.Next(s.Length)]).ToArray());
        }
    }
}
