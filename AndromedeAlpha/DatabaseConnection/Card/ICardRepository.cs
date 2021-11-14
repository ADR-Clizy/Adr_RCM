using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public interface ICardRepository
    {
        Card GetCardWithId(int iId);
        Card NewCard(Card ioRestorer);
        Card UpdateCard(Card ioRestorerChanges);
        Card DeleteCard(int iId);
    }
}
