/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using System.Collections.Generic;
using System.Linq;

namespace DatabaseConnection
{
    public class SQLRestorerRepository : IRestorerRepository
    {
        private readonly AndromedeDbContext _context;

        public SQLRestorerRepository(AndromedeDbContext context)
        {
            _context = context;
        }

        public Restorer DeleteProfile(int iId)
        {
            Restorer aRestorer = _context.Restorers.Find(iId);
            if(aRestorer != null)
            {
                _context.Restorers.Remove(aRestorer);
                _context.SaveChanges();
            }
            return aRestorer;
        }

        public Restorer NewRestorer(Restorer ioRestorer)
        {
            _context.Restorers.Add(ioRestorer);
            _context.SaveChanges();
            return ioRestorer;
        }

        public Restorer UpdateProfile(Restorer ioRestorerChanges)
        {
            var aRestorer = _context.Restorers.Attach(ioRestorerChanges);
            aRestorer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return ioRestorerChanges;
        }

        public IEnumerable<Restorer> GetAllRestorer()
        {
            return _context.Restorers;
        }

        public Restorer GetRestorerWithEmailAddress(string iEmailAddress)
        {
            return _context.Restorers.FirstOrDefault(aRestorer => aRestorer.EmailAddress == iEmailAddress);
        }

        public Restorer GetRestorerWithId(int iId)
        {
            return _context.Restorers.Find(iId);
        }

        public Restorer GetRestorerWithRestaurantSiretNumber(string iRestaurantSiretNumber)
        {
            return _context.Restorers.FirstOrDefault(aRestorer => aRestorer.RestaurantSiretNumber == iRestaurantSiretNumber);
        }

        public bool IsRestorerSubscribed(int iId)
        {
            return _context.Restorers.Find(iId).Subscribed;
        }

        public List<Card> GetCards(int iId)
        {
            return _context.Cards.Where(aCard => iId == aCard.RestorerId).ToList();
        }

        public List<RestorerClaim> GetRestorerClaims(int iId)
        {
            return _context.RestorerClaims.Where(aRestorerClaim => iId == aRestorerClaim.RestorerId).ToList();
        }
    }
}
