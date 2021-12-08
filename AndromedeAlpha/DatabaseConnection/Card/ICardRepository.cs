/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

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
