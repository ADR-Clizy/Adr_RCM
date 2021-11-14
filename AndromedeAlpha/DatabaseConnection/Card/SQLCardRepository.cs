using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class SQLCardRepository : ICardRepository
    {
        private readonly AndromedeDbContext _context;

        public SQLCardRepository(AndromedeDbContext context)
        {
            _context = context;
        }

        public Card DeleteCard(int iId)
        {
            Card aCard = _context.Cards.Find(iId);
            if(aCard != null)
            {
                _context.Cards.Remove(aCard);
                _context.SaveChanges();
            }
            return aCard;
        }

        public Card GetCardWithId(int iId)
        {
            return _context.Cards.Find(iId);
        }

        public Card NewCard(Card ioCard)
        {
            _context.Cards.Add(ioCard);
            _context.SaveChanges();
            return ioCard;
        }

        public Card UpdateCard(Card ioCardChanges)
        {
            var aCard = _context.Cards.Attach(ioCardChanges);
            aCard.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return ioCardChanges;
        }
    }
}
